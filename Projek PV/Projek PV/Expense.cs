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

    public partial class Expense : Form
    {
        string connectionString;
        public Expense(string connectionString  )
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        private void Expense_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Mohon lengkapi semua data pengeluaran.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveExpense(dateTimePicker1.Value, textBox1.Text, textBox2.Text, numericUpDown1.Value);
        }

        private void SaveExpense(DateTime tgl, string kat, string desc, decimal jml)
        {
            // Pastikan connectionString sudah didefinisikan di class Anda
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // Query INSERT
                string query = @"INSERT INTO expense (expense_date, category, description, amount, created_at) 
                         VALUES (@date, @cat, @desc, @amount, NOW())";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Menambahkan parameter untuk mencegah SQL Injection
                    cmd.Parameters.AddWithValue("@date", tgl.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@cat", kat);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@amount", jml);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Pengeluaran berhasil dicatat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // ResetForm(); // Panggil fungsi reset input Anda jika ada
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
