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
        private int leaseId;
        private string connectionString;

        public FormTagihListrikTenant(int leaseId, string connStr)
        {
            InitializeComponent();
            this.leaseId = leaseId;
            this.connectionString = connStr;

            LoadTagihanListrik();
        }

        private void LoadTagihanListrik()
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
                            decimal kwh = Convert.ToDecimal(reader["pemakaian_kwh"]);
                            decimal tarif = Convert.ToDecimal(reader["tarif_per_kwh"]);
                            decimal total = Convert.ToDecimal(reader["total_tagihan"]);

                            int tenantId = Convert.ToInt32(reader["tenant_id"]);
                            string tenantName = reader["full_name"].ToString();

                            // ================= UI =================
                            textBoxTenant.Text = tenantName;
                            textBoxTenant.ReadOnly = true;

                            // === ISI KE LABEL ===
                            labelkWh.Text = $"{kwh:N2} kWh";
                            labelTarif.Text = $"Rp {tarif:N0}";
                            labelEstimasi.Text = $"Rp {total:N0}";

                            // === ISI KE INPUT (ADMIN EDIT) ===
                            numKwh.Value = kwh;
                            numTarif.Value = tarif;
                        }
                        else
                        {
                            labelkWh.Text = "0 kWh";
                            labelTarif.Text = "Rp 0";
                            labelEstimasi.Text = "Rp 0";

                            numKwh.Value = 0;
                            numTarif.Value = 0;
                        }
                    }
                }
            }
        }


    }
}
