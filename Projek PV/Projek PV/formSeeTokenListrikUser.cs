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
    public partial class formSeeTokenListrikUser : Form
    {
        private int transactionId;
        private string connectionString;
        public formSeeTokenListrikUser(int transactionId, string connectionString)
        {
            InitializeComponent();
            this.transactionId = transactionId;
            this.connectionString = connectionString;
        }
        private void formSeeTokenListrikUser_Load(object sender, EventArgs e)
        {
            loadTokenUser();
        }

        private void loadTokenUser()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT
                    lb.pemakaian_kwh,
                    lb.total_tagihan,
                    lt.token_code
                FROM listrik_bills lb
                LEFT JOIN listrik_tokens lt
                    ON lt.bill_id = lb.bill_id
                WHERE lb.transaction_id = @transaction_id;

                ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@transaction_id", transactionId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelRequestToken.Text = reader["pemakaian_kwh"] + " kWh";
                            labelTotalBayar.Text = "Rp " +
                                Convert.ToDecimal(reader["total_tagihan"]).ToString("N0");

                            if (reader["token_code"] != DBNull.Value)
                            {
                                labelTokenListrik.Text = reader["token_code"].ToString();
                                labelTokenListrik.ForeColor = Color.DarkGreen;
                            }
                            else
                            {
                                labelTokenListrik.Text = "Token belum tersedia";
                                labelTokenListrik.ForeColor = Color.Gray;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data token tidak ditemukan.");
                        }
                    }
                }

            }
        }

        
    }
}

