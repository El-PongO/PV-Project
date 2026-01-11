using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class Announcement : Form
    {
        int tenant_id;
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        public Announcement(int tenant_id)
        {
            InitializeComponent();
            this.tenant_id = tenant_id;

            LoadNotifications(tenant_id);



        }


        private void LoadNotifications(int id_tenant)
        {
            string query = @"
            SELECT 
                title AS Judul, 
                content AS Pesan, 
                created_at AS Waktu 
            FROM announcements 
            WHERE is_active = 1 
        
            UNION 
        
            SELECT 
                CONCAT('Balasan: ', category) AS Judul, 
                admin_reply AS Pesan, 
                reply_at AS Waktu 
            FROM complaints 
            WHERE tenant_id = @tenant AND admin_reply IS NOT NULL 
        
            UNION 
        
            SELECT 
                title AS Judul, 
                content AS Pesan, 
                created_at AS Waktu 
            FROM reminders 
            WHERE tenant_id = @tenant 
        
            ORDER BY Waktu DESC";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Mengisi Parameter
                        cmd.Parameters.AddWithValue("@tenant", id_tenant);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // 1. Masukkan data ke DataGridView1
                            dataGridView1.DataSource = dt;

                            // 2. Terapkan Styling agar cantik
                            StyleNotificationGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat notifikasi: " + ex.Message);
                }
            }
        }

        // Method terpisah untuk styling agar kodenya rapi
        private void StyleNotificationGrid()
        {
            // --- Konfigurasi Dasar ---
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false; // Hilangkan selector di kiri
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowTemplate.Height = 50; // Baris agak tinggi karena isi pesan mungkin panjang

            // --- Header Style ---
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48); // Warna Gelap
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            // --- Content Style ---
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.DefaultCellStyle.Padding = new Padding(5);
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Agar teks panjang turun ke bawah (Wrap)

            // Warna selang-seling
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // --- Pengaturan Per Kolom ---

            // 1. Kolom Judul
            if (dataGridView1.Columns.Contains("Judul"))
            {
                dataGridView1.Columns["Judul"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dataGridView1.Columns["Judul"].DefaultCellStyle.ForeColor = Color.DarkBlue;
            }

            // 2. Kolom Pesan
            if (dataGridView1.Columns.Contains("Pesan"))
            {
                // Kolom pesan akan mengisi sisa ruang
                dataGridView1.Columns["Pesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // 3. Kolom Waktu
            if (dataGridView1.Columns.Contains("Waktu"))
            {
                dataGridView1.Columns["Waktu"].DefaultCellStyle.Format = "dd MMM HH:mm"; // Contoh: 12 Jan 14:30
                dataGridView1.Columns["Waktu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Waktu"].DefaultCellStyle.ForeColor = Color.Gray;
            }
        }
    }
}
