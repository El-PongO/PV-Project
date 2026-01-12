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
    public partial class Tagihan : Form
    {
        String connectionString;
        public Tagihan(String connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            LoadActiveLeases();
        }


        private void LoadActiveLeases()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Ambil Lease yang AKTIF saja
                    string query = @"
                    SELECT 
                        l.lease_id, 
                        CONCAT(r.room_number, ' - ', t.full_name) AS display_name
                    FROM leases l
                    JOIN rooms r ON l.room_id = r.room_id
                    JOIN tenants t ON l.tenant_id = t.tenant_id
                    WHERE l.status = 'Active'
                    ORDER BY r.room_number ASC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Binding ke ComboBox
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "display_name"; // Yang dilihat user
                    comboBox1.ValueMember = "lease_id";       // Yang diambil kodingan
                    comboBox1.SelectedIndex = -1;             // Kosongkan pilihan awal
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data penyewa: " + ex.Message);
                }
            }
        }

        // Panggil ini di Form_Load
        private void FormManualBill_Load(object sender, EventArgs e)
        {
            LoadActiveLeases();

            // Isi manual kategori sesuai Enum Database Anda
            comboBox2.Items.Add("damages");     // Kerusakan/Denda
            comboBox2.Items.Add("electricity"); // Listrik
            comboBox2.Items.Add("rent");        // Sewa
            comboBox2.Items.Add("others");        // Sewa
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Penyewa/Kamar terlebih dahulu.");
                return;
            }
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Kategori Tagihan.");
                return;
            }
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Nominal tagihan harus lebih dari 0.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Mohon isi keterangan tagihan (Misal: Ganti Kunci Hilang).");
                return;
            }

            // 2. Ambil Data
            int leaseId = Convert.ToInt32(comboBox1.SelectedValue);
            string kategori = comboBox2.Text; // 'damages', 'rent', etc
            decimal amount = numericUpDown1.Value;
            string description = textBox2.Text;
            DateTime jatuhTempo = dateTimePicker1.Value;

            // 3. Simpan ke Database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // Query Insert Transaction
                // Status = Pending (Belum Lunas)
                // Payment Method = NULL (Karena belum dibayar)
                string query = @"
            INSERT INTO transactions 
            (lease_id, transaction_date, description, amount, status, category, payment_due_by, payment_method) 
            VALUES 
            (@lid, NOW(), @desc, @amt, 'Pending', @cat, @due, NULL)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lid", leaseId);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@amt", amount);
                    cmd.Parameters.AddWithValue("@cat", kategori);
                    cmd.Parameters.AddWithValue("@due", jatuhTempo);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Tagihan berhasil dibuat! Status: Pending.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reset Form
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menyimpan tagihan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
