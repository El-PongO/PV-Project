using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            numericUpDown1.Maximum = 12;
            numericUpDown2.Maximum = 3000;

            numericUpDown1.Value = 1;
            numericUpDown2.Value = 2025;

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
            if (radioButton1.Checked)
            {
                laporanKamar();
            }

            if(radioButton2.Checked)
            {
                laporanKeuangan();
            }

             reset();
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
    }

}
