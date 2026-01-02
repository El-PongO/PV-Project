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

        public FormTagihListrikTenant(int tenantId, int leaseId, string connStr)
        {
            InitializeComponent();
            this.leaseId = leaseId;
            this.connectionString = connStr;
            this.tenantId = tenantId;

            LoadTenantName();
            LoadTagihanTerakhir();
            MessageBox.Show("Tenant ID: " + tenantId);

        }

        private void LoadTenantName()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT full_name FROM tenants WHERE tenant_id = @tenantId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        textBoxTenant.Text = result.ToString();
                    }
                }
            }
        }

        private void LoadTagihanTerakhir()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        SELECT pemakaian_kwh, tarif_per_kwh, total_tagihan
        FROM listrik_bills
        WHERE lease_id = @leaseId
        ORDER BY created_at DESC
        LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@leaseId", leaseId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            numKwh.Value = Convert.ToDecimal(reader["pemakaian_kwh"]);
                            numTarif.Value = Convert.ToDecimal(reader["tarif_per_kwh"]);
                        }
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            decimal total = numKwh.Value * numTarif.Value;

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
                    cmd.Parameters.AddWithValue("@tarif", numTarif.Value);
                    cmd.Parameters.AddWithValue("@total", total);

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
            decimal tarif = numTarif.Value;
            decimal total = kwh * tarif;

            labelkWh.Text = $"{kwh} kWh";
            labelTarif.Text = $"Rp {tarif:N0}";
            labelEstimasi.Text = $"Rp {total:N0}";
        }


        private void num_ValueChanged(object sender, EventArgs e)
        {
            UpdateEstimasi();
        }
    }
}
