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
        private int billId;
        private string connectionString;
        public formSeeTokenListrikUser(int billId, string connectionString)
        {
            InitializeComponent();
            this.billId = billId;
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
JOIN listrik_tokens lt 
    ON lb.bill_id = lt.bill_id
WHERE lb.bill_id = @bill_id;
";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bill_id", billId);

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

