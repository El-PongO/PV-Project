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
    public partial class FormTagihListrikTenant : Form
    {
        private int tenantId;
        private int leaseId;
        private string connectionString;
        private int tariff = 450; // Tarif per kWh tetap

        public FormTagihListrikTenant(int tenantId, int leaseId, string connStr)
        {
            InitializeComponent();
            this.leaseId = leaseId;
            this.connectionString = connStr;
            this.tenantId = tenantId;

            MessageBox.Show("Tenant ID: " + tenantId);

        }



        private void buttonSave_Click(object sender, EventArgs e)
        {

            if(numKwh.Value <= 0)
            {
                MessageBox.Show("Jumlah kWh harus lebih dari 0");
                return;
            }
            if(comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih Pembayaran!");
                return;
            }

            decimal total = numKwh.Value * tariff;

    

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                INSERT INTO listrik_bills
                (lease_id, pemakaian_kwh, tarif_per_kwh, total_tagihan, bill_month, due_date)
                VALUES
                (@leaseId, @kwh, @tarif, @total, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 7 DAY))";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@leaseId", leaseId);
                    cmd.Parameters.AddWithValue("@kwh", numKwh.Value);
                    cmd.Parameters.AddWithValue("@tarif", tariff);
                    cmd.Parameters.AddWithValue("@total", total);

                    cmd.ExecuteNonQuery();
                }
            }

            //insert ke tagihan -> ini yang rill
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                INSERT INTO transactions
                (lease_id, description, amount, payment_method, status, category)
                VALUES
                (@leaseId, @desc, @total, @method, @status, @cat)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@leaseId", leaseId);
                    cmd.Parameters.AddWithValue("@desc", "Pembelian Token Listrik");
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@method", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@status", "Paid");
                    cmd.Parameters.AddWithValue("@cat", "electricity");

                    cmd.ExecuteNonQuery();
                }
            }


            MessageBox.Show("Tagihan listrik berhasil disimpan");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateEstimasi()
        {
            decimal kwh = numKwh.Value;
            decimal total = kwh * tariff;

            labelkWh.Text = $"{kwh} kWh";
            labelEstimasi.Text = $"Rp {total:N0}";
        }


        private void num_ValueChanged(object sender, EventArgs e)
        {
            UpdateEstimasi();
        }
    }
}
