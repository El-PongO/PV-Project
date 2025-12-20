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
    public partial class payment : Form
    {
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        int payment_id;
        public payment(int id)
        {
            payment_id = id;   
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string query = "Update transactions set payment_method = @method, status = @stats where transaction_id = @id";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@method", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@stats", "Paid");
                        cmd.Parameters.AddWithValue("@id", payment_id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("paid successfully!");
                            MessageBox.Show("Terima Kasih, jangan lupa kirim bukti pembayaran!");
                            this.Close();
                        }
                        else
                        {
                            Console.WriteLine("pay failed.");
                        }
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
