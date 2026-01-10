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
    public partial class tamuTerdaftarUser : Form
    {
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";
        int tenantId;

        public tamuTerdaftarUser(int tenant_id)
        {
            InitializeComponent();
            tenantId = tenant_id;
            AturDesainDGV(dataGridView1);
            loadDgv();
            if (!dataGridView1.Columns.Contains("btnAksi"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Aksi";
                btn.Name = "btnAksi";
                btn.Text = "Cancel"; // Tulisan di tombol
                btn.UseColumnTextForButtonValue = true; // Agar tulisan muncul di semua baris

                // Tambahkan ke paling akhir
                dataGridView1.Columns.Add(btn);
            }

        }

        public void loadDgv()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT guest_id, guest_name, visit_date, arrival_time, purpose FROM guest_logs WHERE tenant_id = " + tenantId;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnAksi"].Index && e.RowIndex >= 0)
            {
                // 2. Konfirmasi User (Opsional tapi disarankan)
                DialogResult dialog = MessageBox.Show("Cancel Kunjungan Tamu?",
                                                      "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells["guest_id"].Value.ToString();
                    string query = "delete from guest_logs where guest_id = @id";

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery(); // Eksekusi query tanpa return data
                            }

                            // Pesan sukses
                            MessageBox.Show("Cancel Berhasil!");

                            loadDgv(); // Refresh DataGridView
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gagal hapus: " + ex.Message);
                        }
                    }
                }
            }
        }


        private void AturDesainDGV(DataGridView dgv)
        {
            // --- 1. PENGATURAN UMUM ---
            dgv.BorderStyle = BorderStyle.None;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(87, 166, 219); // Warna saat baris dipilih (Biru kalem)
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White; // Background utama putih

            // Hilangkan border header kolom
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // --- 2. HEADER KOLOM (BAGIAN ATAS) ---
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72); // Biru Gelap (Navy) agar elegan
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Font modern
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 40; // Header sedikit tinggi agar lega

            // --- 3. ISI BARIS (ROW) ---
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); // Hitam keabuan (lebih enak di mata)
            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0); // Jarak teks kiri-kanan
            dgv.RowTemplate.Height = 35; // Tinggi baris data

            // --- 4. BEHAVIOR ---
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Klik satu sel, terpilih satu baris
            dgv.MultiSelect = false; // Mencegah user memilih banyak baris sekaligus
            dgv.RowHeadersVisible = false; // Hilangkan kotak abu-abu jelek di paling kiri
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Kolom memenuhi lebar grid
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;


        }

    }
}
