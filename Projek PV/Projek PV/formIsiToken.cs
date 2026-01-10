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
    public partial class formIsiToken : Form
    {
        private int billId;
        private int lease_id;
        private decimal requestKwh;
        private decimal totalBayar;
        private string connectionString;

        public formIsiToken(int billId, string connectionString)
        {
            InitializeComponent();
            this.billId = billId;
            this.connectionString = connectionString;
        }

        private void formIsiToken_Load(object sender, EventArgs e)
        {
            LoadRequestToken();
        }

        private void LoadRequestToken()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT lease_id, pemakaian_kwh, total_tagihan
            FROM listrik_bills
            WHERE bill_id = @billId
        ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billId", billId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lease_id = Convert.ToInt32(reader["lease_id"]);
                            requestKwh = Convert.ToDecimal(reader["pemakaian_kwh"]);
                            totalBayar = Convert.ToDecimal(reader["total_tagihan"]);

                            //lblLeaseId.Text = leaseId.ToString();
                            MessageBox.Show("lease id: " + lease_id);
                            labelRequestToken.Text = requestKwh + " kWh";
                            labelTotalBayar.Text = "Rp " + totalBayar.ToString("N0");
                        }
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTokenCode.Text))
            {
                MessageBox.Show("Kode token wajib diisi");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trx = conn.BeginTransaction();

                try
                {
                    // 1️⃣ INSERT token
                    string insertToken = @"
                INSERT INTO listrik_tokens
                (lease_id, bill_id, token_kwh, token_value, token_code)
                VALUES
                (@leaseId, @billId, @tokenKwh, @tokenValue, @tokenCode)
            ";

                    using (MySqlCommand cmd = new MySqlCommand(insertToken, conn, trx))
                    {
                        cmd.Parameters.AddWithValue("@leaseId", lease_id);
                        cmd.Parameters.AddWithValue("@billId", billId);
                        cmd.Parameters.AddWithValue("@tokenKwh", requestKwh);
                        cmd.Parameters.AddWithValue("@tokenValue", totalBayar);
                        cmd.Parameters.AddWithValue("@tokenCode", textBoxTokenCode.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }

                    string insertExpense = @"
                INSERT INTO expense
                (expense_date, category, description, amount)
                VALUES
                (CURDATE(), 'Listrik', @desc, @amount)
            ";

                    using (MySqlCommand cmd = new MySqlCommand(insertExpense, conn, trx))
                    {
                        cmd.Parameters.AddWithValue(
                            "@desc",
                            $"Token listrik lease ID {lease_id} (Bill ID {billId})"
                        );
                        cmd.Parameters.AddWithValue("@amount", totalBayar);
                        cmd.ExecuteNonQuery();
                    }

                    // 2️⃣ UPDATE admin_status
                    string updateBill = @"
                UPDATE listrik_bills
                SET admin_status = 'Done'
                WHERE bill_id = @billId
            ";

                    using (MySqlCommand cmd = new MySqlCommand(updateBill, conn, trx))
                    {
                        cmd.Parameters.AddWithValue("@billId", billId);
                        cmd.ExecuteNonQuery();
                    }

                    trx.Commit();

                    MessageBox.Show("Token berhasil dimasukkan");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show("Gagal menyimpan token: " + ex.Message);
                }
            }
        }
    }
}
