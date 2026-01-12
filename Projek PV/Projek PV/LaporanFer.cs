using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projek_PV
{
    public partial class LaporanFer : Form
    {
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        public LaporanFer()
        {
            InitializeComponent();
            lblTotalSaldo.Text = "";

        }

        public void reset()
        {
            groupBox2.Enabled = true;
            numericUpDown1.Maximum = 12;
            numericUpDown2.Maximum = 3000;

            if (radioButton3.Checked)
            {
                groupBox2.Enabled = false;
            }


        }

        private void setupDGV()
        {
            // --- 1. Konfigurasi Dasar (Flat Design) ---
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false; // Wajib false agar header bisa diwarnai

            // Hilangkan row header (selector di kiri)
            dataGridView1.RowHeadersVisible = false;

            // Mode Seleksi & Ukuran
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40; // Tinggi baris agar lega

            // --- 2. Styling Header (Judul Kolom) ---
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48); // Warna Gelap Modern
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 45;

            // --- 3. Styling Baris (Rows) ---
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridView1.DefaultCellStyle.Padding = new Padding(6);

            // Warna saat baris dipilih (Hijau Soft Modern)
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 247, 235);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Warna selang-seling (Alternating Rows)
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setupDGV();
            lblTotalSaldo.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            if (radioButton1.Checked)
            {
                laporanKamar();
            }

            if (radioButton2.Checked)
            {
                laporanKeuangan();
            }

            if (radioButton4.Checked)
            {
                laporanJatuhTempoSewa();
            }
            if (radioButton5.Checked)
            {
                laporanKomplen();
            }
            if (radioButton6.Checked)
            {
                laporanListrik();
            }
            if (radioButton3.Checked)
            {
                loadTunggakan();
            }

                reset();
        }

        private void loadTunggakan()
        {

            
            string query = @"
            SELECT 
                l.tenant_id AS ID_Tenant, 
                t.full_name AS Nama_Penyewa,
                r.room_number AS Kamar,
                DATE_FORMAT(tr.transaction_date, '%d-%m-%Y') AS Tgl_Tagihan,
                tr.description AS Keterangan,
                tr.amount AS Total_Utang,
                DATEDIFF(NOW(), tr.transaction_date) AS Hari_Telat
            FROM transactions tr
            JOIN leases l ON tr.lease_id = l.lease_id
            JOIN tenants t ON l.tenant_id = t.tenant_id
            JOIN rooms r ON l.room_id = r.room_id
            WHERE tr.status IN ('Pending', 'Failed')
            ORDER BY tr.transaction_date ASC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // 1. Sembunyikan ID_Tenant
                    if (dataGridView1.Columns.Contains("ID_Tenant"))
                        dataGridView1.Columns["ID_Tenant"].Visible = false;

                    // 2. Styling Format Uang
                    if (dataGridView1.Columns.Contains("Total_Utang"))
                    {
                        dataGridView1.Columns["Total_Utang"].DefaultCellStyle.Format = "N0";
                        dataGridView1.Columns["Total_Utang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // 4. Style Dasar
                    ColorizeArrearsRows();
                    // Cek agar tombol tidak double (duplikat)
                    if (!dataGridView1.Columns.Contains("btnReminder"))
                    {
                        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                        btn.HeaderText = "Aksi";
                        btn.Name = "btnReminder";
                        btn.Text = "Remind";
                        btn.UseColumnTextForButtonValue = true; // Munculkan teks di tombol

                        // Tambahkan di kolom paling akhir
                        dataGridView1.Columns.Add(btn);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ColorizeArrearsRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // Warnai Merah Semua (Karena ini daftar masalah)
                row.DefaultCellStyle.ForeColor = Color.Red;

                // Jika Telat > 30 Hari, Background jadi Merah Muda (Warning Keras)
                var cellValue = row.Cells["Hari_Telat"].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int hari) && hari > 30)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }



            // Sembunyikan ID_Tenant agar rapi
            if (dataGridView1.Columns.Contains("ID_Tenant"))
                dataGridView1.Columns["ID_Tenant"].Visible = false;
        }

        private void laporanListrik()
        {
            string query = @"
            SELECT 
                DATE_FORMAT(lb.bill_month, '%M %Y') AS Periode,
                r.room_number AS Kamar,
                t.full_name AS Nama_Penyewa,
                lb.pemakaian_kwh AS Pakai_kWh,
                lb.tarif_per_kwh AS Tarif,
                lb.total_tagihan AS Total_Biaya,
                lb.status AS Status
            FROM listrik_bills lb
            JOIN leases l ON lb.lease_id = l.lease_id
            JOIN tenants t ON l.tenant_id = t.tenant_id
            JOIN rooms r ON l.room_id = r.room_id
            WHERE MONTH(lb.bill_month) = @bulan
            AND YEAR(lb.bill_month) = @tahun
            ORDER BY r.room_number ASC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parameter Filter (Wajib)
                    cmd.Parameters.AddWithValue("@bulan", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tahun", numericUpDown2.Value);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // --- STYLING ---
                    SetupDataGridViewStyle(); // Panggil style dasar

                    // Format Angka Desimal & Rupiah
                    if (dataGridView1.Columns.Contains("Total_Biaya"))
                    {
                        dataGridView1.Columns["Total_Biaya"].DefaultCellStyle.Format = "N0";
                        dataGridView1.Columns["Total_Biaya"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    if (dataGridView1.Columns.Contains("Pakai_kWh"))
                    {
                        dataGridView1.Columns["Pakai_kWh"].DefaultCellStyle.Format = "N2"; // 2 angka belakang koma
                        dataGridView1.Columns["Pakai_kWh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    if (dataGridView1.Columns.Contains("Tarif"))
                    {
                        dataGridView1.Columns["Tarif"].DefaultCellStyle.Format = "N0";
                    }

                    // Pewarnaan Status (Merah/Hijau)
                    ColorizeElectricityRows();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void ColorizeElectricityRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var status = row.Cells["Status"].Value?.ToString();

                if (status == "Paid")
                {
                    row.Cells["Status"].Style.ForeColor = Color.SeaGreen;
                }
                else
                {
                    row.Cells["Status"].Style.ForeColor = Color.Red;
                    row.Cells["Status"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

        private void laporanKomplen()
        {
            string query = @"
            SELECT 
                c.complaint_id AS ID,
                DATE_FORMAT(c.created_at, '%d-%m-%Y') AS Tanggal,
                t.full_name AS Pelapor,
                COALESCE(r.room_number, '-') AS Kamar,
                c.category AS Kategori,
                c.description AS Keluhan,
                COALESCE(c.admin_reply, '-') AS Tanggapan,
                c.status AS Status_Raw, 
                UPPER(c.status) AS Status
            FROM complaints c
            JOIN tenants t ON c.tenant_id = t.tenant_id
            LEFT JOIN leases l ON t.tenant_id = l.tenant_id AND l.status = 'Active'
            LEFT JOIN rooms r ON l.room_id = r.room_id
            WHERE MONTH(c.created_at) = @bulan 
            AND YEAR(c.created_at) = @tahun
            ORDER BY FIELD(c.status, 'Menunggu', 'Proses', 'Selesai'), c.created_at ASC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parameter
                    cmd.Parameters.AddWithValue("@bulan", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tahun", numericUpDown2.Value);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // --- STYLING ---

                    // 1. Sembunyikan kolom ID dan Status Raw
                    if (dataGridView1.Columns.Contains("ID")) dataGridView1.Columns["ID"].Visible = false;
                    if (dataGridView1.Columns.Contains("Status_Raw")) dataGridView1.Columns["Status_Raw"].Visible = false;

                    // 2. Atur lebar kolom agar rapi
                    if (dataGridView1.Columns.Contains("Keluhan")) dataGridView1.Columns["Keluhan"].FillWeight = 200; // Lebih lebar
                    if (dataGridView1.Columns.Contains("Tanggapan")) dataGridView1.Columns["Tanggapan"].FillWeight = 150;

                    // 3. Flat Design
                    SetupDataGridViewStyle();

                    // 4. Warnai Baris Berdasarkan Status
                    ColorizeComplaintRows();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void ColorizeComplaintRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var status = row.Cells["Status_Raw"].Value?.ToString();

                if (status == "Menunggu")
                {
                    // MERAH: Masalah Baru / Belum disentuh
                    row.Cells["Status"].Style.ForeColor = Color.Red;
                    row.Cells["Status"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                    // Highlight background biar menyolok
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                }
                else if (status == "Proses")
                {
                    // ORANYE: Sedang dikerjakan
                    row.Cells["Status"].Style.ForeColor = Color.DarkOrange;
                    row.Cells["Status"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 225); // Kuning muda
                }
                else if (status == "Selesai")
                {
                    // HIJAU: Aman
                    row.Cells["Status"].Style.ForeColor = Color.SeaGreen;
                }
            }
        }
        void laporanJatuhTempoSewa()
        {
            string query = @"
            SELECT 
                r.room_number AS Kamar,
                t.full_name AS Nama_Penyewa,
                t.phone_number AS No_HP,
                DATE_FORMAT(l.end_date, '%d-%m-%Y') AS Tgl_Berakhir,
            
                -- Kolom angka untuk logika warna (Sembunyikan nanti)
                DATEDIFF(l.end_date, CURDATE()) AS Sisa_Hari_Angka, 

                -- Kolom Teks untuk user
                CASE 
                    WHEN DATEDIFF(l.end_date, CURDATE()) < 0 THEN 'Sudah Lewat'
                    WHEN DATEDIFF(l.end_date, CURDATE()) = 0 THEN 'Jatuh Tempo HARI INI'
                    ELSE CONCAT(DATEDIFF(l.end_date, CURDATE()), ' Hari Lagi')
                END AS Status_Waktu,
            
                l.rent_price AS Harga_sewa
            FROM leases l
            JOIN rooms r ON l.room_id = r.room_id
            JOIN tenants t ON l.tenant_id = t.tenant_id
            WHERE l.status = 'Active' 
            AND MONTH(l.end_date) = @bulan 
            AND YEAR(l.end_date) = @tahun
            ORDER BY l.end_date ASC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parameter
                    cmd.Parameters.AddWithValue("@bulan", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tahun", numericUpDown2.Value);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // --- STYLING ---

                    // 1. Sembunyikan kolom bantuan (Angka Sisa Hari)
                    if (dataGridView1.Columns.Contains("Sisa_Hari_Angka"))
                        dataGridView1.Columns["Sisa_Hari_Angka"].Visible = false;

                    // 2. Format Rupiah untuk tagihan
                    if (dataGridView1.Columns.Contains("Tagihan_Berikutnya"))
                    {
                        dataGridView1.Columns["Tagihan_Berikutnya"].DefaultCellStyle.Format = "N0";
                        dataGridView1.Columns["Tagihan_Berikutnya"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // 3. Terapkan Flat Design
                    SetupDataGridViewStyle();

                    // 4. Warnai Baris Berdasarkan Urgensi
                    ColorizeExpiryRows();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void ColorizeExpiryRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // Ambil nilai sisa hari (angka)
                var cellValue = row.Cells["Sisa_Hari_Angka"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int sisaHari))
                {
                    if (sisaHari < 0)
                    {
                        // KASUS 1: SUDAH LEWAT (Expired)
                        // Warna Merah Terang
                        row.Cells["Status_Waktu"].Style.ForeColor = Color.Red;
                        row.Cells["Status_Waktu"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        row.Cells["Tgl_Berakhir"].Style.ForeColor = Color.Red;

                        // Beri background merah tipis agar menyolok
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    }
                    else if (sisaHari <= 7)
                    {
                        // KASUS 2: WARNING (0 - 7 Hari lagi)
                        // Warna Oranye/Emas
                        row.Cells["Status_Waktu"].Style.ForeColor = Color.DarkGoldenrod;
                        row.Cells["Status_Waktu"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                    else
                    {
                        // KASUS 3: AMAN (Masih lama)
                        row.Cells["Status_Waktu"].Style.ForeColor = Color.SeaGreen;
                    }
                }
            }
        }


        void laporanKeuangan()
        {
            string query = @"
                SELECT 
                    tr.transaction_date AS Tanggal_Raw, -- Untuk sorting
                    DATE_FORMAT(tr.transaction_date, '%d-%m-%Y') AS Tanggal,
                    
                    CASE 
                        WHEN tr.category = 'electricity' THEN 'Pendapatan Listrik'
                        WHEN tr.category = 'rent' THEN 'Uang Sewa'
                        ELSE tr.category 
                    END AS Kategori,

                    tr.description AS Keterangan,
                    tr.amount AS Nominal,
                    'Pemasukan' AS Tipe
                FROM transactions tr
                WHERE tr.status = 'Paid'
                AND MONTH(tr.transaction_date) = @bulan 
                AND YEAR(tr.transaction_date) = @tahun

                UNION ALL

                SELECT 
                    e.expense_date AS Tanggal_Raw,
                    DATE_FORMAT(e.expense_date, '%d-%m-%Y') AS Tanggal,
                    
                    CASE 
                        WHEN e.category LIKE '%Listrik%' THEN 'Beli Token Listrik'
                        ELSE e.category 
                    END AS Kategori,

                    e.description AS Keterangan,
                    (e.amount * -1) AS Nominal, -- Ubah jadi Negatif
                    'Pengeluaran' AS Tipe
                FROM expense e
                WHERE MONTH(e.expense_date) = @bulan 
                AND YEAR(e.expense_date) = @tahun

                ORDER BY Tanggal_Raw ASC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parameter Input User
                    cmd.Parameters.AddWithValue("@bulan", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tahun", numericUpDown2.Value);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // 1. Masukkan Data ke Grid
                    dataGridView1.DataSource = dt;

                    // 2. Sembunyikan kolom teknis
                    if (dataGridView1.Columns.Contains("Tanggal_Raw")) dataGridView1.Columns["Tanggal_Raw"].Visible = false;
                    if (dataGridView1.Columns.Contains("Tipe")) dataGridView1.Columns["Tipe"].Visible = false;

                    // 3. Terapkan Styling & Warna
                    SetupDataGridViewStyle();
                    ColorizeFinancialRows();

                    // 4. Hitung Total Saldo
                    CalculateBalance(dt);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }

        }


        public void laporanKamar()
        {
            string query = @"
                SELECT 
                    r.room_number AS No_Kamar,
                    r.type AS Tipe,
                    r.base_price AS Harga,
                    COALESCE(t.full_name, '-') AS Nama_Penghuni,
        
                    -- Tambahan: Menampilkan Tgl Masuk juga biar informatif (Opsional, boleh dihapus jika tidak butuh)
                    COALESCE(DATE_FORMAT(l.start_date, '%d-%m-%Y'), '-') AS Tgl_Masuk, 
                    COALESCE(DATE_FORMAT(l.end_date, '%d-%m-%Y'), '-') AS Tgl_Selesai_Sewa,

                    -- LOGIKA STATUS
                    CASE 
                        -- 1. Cek Perbaikan
                        WHEN r.status = 'Perbaikan' THEN 'Perbaikan'
            
                        -- 2. Cek Keluar (Prioritas Warning: Akan Kosong)
                        WHEN l.lease_id IS NOT NULL 
                             AND MONTH(l.end_date) = @bulan 
                             AND YEAR(l.end_date) = @tahun 
                             THEN 'Keluar Bulan Ini'
            
                        -- 3. Cek Masuk (LOGIKA BARU DISINI)
                        WHEN l.lease_id IS NOT NULL
                             AND MONTH(l.start_date) = @bulan
                             AND YEAR(l.start_date) = @tahun
                             THEN 'Masuk Bulan Ini'

                        -- 4. Sisanya berarti Terisi lama
                        WHEN l.lease_id IS NOT NULL THEN 'Terisi'
            
                        -- 5. Tidak ada sewa
                        ELSE 'Kosong'
                    END AS Status_Okupansi

                FROM rooms r
                LEFT JOIN leases l ON r.room_id = l.room_id 
                    AND (
                        l.end_date >= STR_TO_DATE(CONCAT(@tahun, '-', @bulan, '-01'), '%Y-%m-%d')
                        AND
                        l.start_date < LAST_DAY(STR_TO_DATE(CONCAT(@tahun, '-', @bulan, '-01'), '%Y-%m-%d'))
                    )
                LEFT JOIN tenants t ON l.tenant_id = t.tenant_id
                ORDER BY r.room_number ASC;
            ";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@bulan", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@tahun", numericUpDown2.Value);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ColorizeStatusRows();
        }

        private void ColorizeStatusRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Pastikan bukan baris baru
                if (row.IsNewRow) continue;

                // Cek apakah kolom "Status_Okupansi" ada di hasil query
                if (dataGridView1.Columns.Contains("Status_Okupansi"))
                {
                    var status = row.Cells["Status_Okupansi"].Value?.ToString();

                    // Logika Pewarnaan
                    if (status == "Kosong")
                    {
                        row.Cells["Status_Okupansi"].Style.ForeColor = Color.SeaGreen;
                        row.Cells["Status_Okupansi"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                    else if (status == "Perbaikan")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235); // Background Merah Muda
                        row.Cells["Status_Okupansi"].Style.ForeColor = Color.Red;
                    }
                    else if (status == "Keluar Bulan Ini")
                    {
                        row.Cells["Status_Okupansi"].Style.ForeColor = Color.DarkGoldenrod;
                        row.Cells["Status_Okupansi"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                    // TAMBAHAN BARU DISINI
                    else if (status == "Masuk Bulan Ini")
                    {
                        row.Cells["Status_Okupansi"].Style.ForeColor = Color.DodgerBlue; // Warna Biru Cerah
                        row.Cells["Status_Okupansi"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                }
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                if (numericUpDown2.Value < DateTime.Now.Year)
                {
                    numericUpDown1.Maximum = 12;
                }
                else
                {
                    numericUpDown1.Maximum = DateTime.Now.Month;
                }
            }
        }

        private void LaporanFer_Load(object sender, EventArgs e)
        {

        }


        private void SetupDataGridViewStyle()
        {
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;

            // Header
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48); // Abu Gelap
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            // Rows
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 247, 235); // Hijau Soft
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 35;
        }

        // --- METHOD PEWARNAAN (Merah vs Hijau) ---
        private void ColorizeFinancialRows()
        {
            // Format Rupiah
            if (dataGridView1.Columns.Contains("Nominal"))
            {
                dataGridView1.Columns["Nominal"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["Nominal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var cellValue = row.Cells["Nominal"].Value;
                if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal amount))
                {
                    if (amount < 0)
                    {
                        // PENGELUARAN (Minus) -> Merah
                        row.Cells["Nominal"].Style.ForeColor = Color.Red;
                        row.Cells["Kategori"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        // PEMASUKAN (Plus) -> Hijau Laut
                        row.Cells["Nominal"].Style.ForeColor = Color.SeaGreen;
                        row.Cells["Kategori"].Style.ForeColor = Color.SeaGreen;
                    }

                    // Tebalkan angka
                    row.Cells["Nominal"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

        // --- METHOD HITUNG SALDO ---
        private void CalculateBalance(DataTable dt)
        {
            decimal totalBersih = 0;

            foreach (DataRow row in dt.Rows)
            {
                // Menjumlahkan semua (karena expense sudah minus, tinggal sum)
                totalBersih += Convert.ToDecimal(row["Nominal"]);
            }

            // Tampilkan ke Label
            lblTotalSaldo.Text = "Laba Bersih: Rp " + totalBersih.ToString("N0");

            // Ubah warna label
            if (totalBersih < 0) lblTotalSaldo.ForeColor = Color.Red;
            else lblTotalSaldo.ForeColor = Color.Green;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked)
            {
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = true;
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan user mengklik tombol "btnSimpanReminder" dan bukan header
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnReminder")
            {
                // 1. Ambil Data dari Baris Terpilih
                string tenantId = dataGridView1.Rows[e.RowIndex].Cells["ID_Tenant"].Value.ToString();
                string nama = dataGridView1.Rows[e.RowIndex].Cells["Nama_Penyewa"].Value.ToString();
                string hutang = dataGridView1.Rows[e.RowIndex].Cells["Total_Utang"].Value.ToString();
                string kamar = dataGridView1.Rows[e.RowIndex].Cells["Kamar"].Value.ToString();

                // Format nominal biar cantik di pesan
                if (decimal.TryParse(hutang, out decimal nilai)) hutang = nilai.ToString("N0");

                // 2. Siapkan Judul dan Isi Reminder Otomatis
                string judul = "Tagihan Belum Lunas";
                string isi = $"Halo {nama} (Kamar {kamar}), sistem mencatat tagihan sebesar Rp {hutang} belum lunas. Mohon segera diselesaikan.";

                // 3. Konfirmasi (Opsional, biar admin yakin)
                DialogResult dr = MessageBox.Show($"Buat reminder untuk {nama}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    string query = "INSERT INTO reminders (tenant_id, title, content, created_at) VALUES (@tid, @title, @content, NOW())";

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            cmd.Parameters.AddWithValue("@tid", tenantId);
                            cmd.Parameters.AddWithValue("@title", judul);
                            cmd.Parameters.AddWithValue("@content", isi);

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Reminder berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gagal menyimpan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
























    }
    
}


