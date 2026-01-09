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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Projek_PV
{
    public partial class formTagihan : Form
    {
        private int tenantId;
        private string connectionString;

        public formTagihan(int tenantId, string connectionStringe)
        {
            InitializeComponent();
            this.tenantId = tenantId;
            this.connectionString = connectionStringe;


            LoadTenantName();
            LoadPaymentMethods();
        }
        private void formTagihKerusakan_Load(object sender, EventArgs e)
        {
        }
        private void LoadTenantName()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT full_name
            FROM tenants
            WHERE tenant_id = @tenant_id
            LIMIT 1
        ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenant_id", tenantId);

                object result = cmd.ExecuteScalar();

                textBoxFullName.Text = result != null ? result.ToString() : "-";
                textBoxFullName.ReadOnly = true;

                //MessageBox.Show("tenant id: " + tenantId);

            }
        }

        private void LoadPaymentMethods()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT DISTINCT payment_method
            FROM transactions
            WHERE payment_method IS NOT NULL
            ORDER BY payment_method
        ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                comboBoxPaymentMethod.Items.Clear();

                while (reader.Read())
                {
                    comboBoxPaymentMethod.Items.Add(
                        reader["payment_method"].ToString()
                    );
                }

                reader.Close();
            }

            // optional default
            if (comboBoxPaymentMethod.Items.Count > 0)
                comboBoxPaymentMethod.SelectedIndex = 0;
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
            {
                MessageBox.Show("Description wajib diisi");
                return;
            }

            if (comboBoxPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Pilih payment method");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string getLeaseQuery = @"
            SELECT lease_id 
            FROM leases 
            WHERE tenant_id = @tenant_id AND status = 'Active'
            LIMIT 1
        ";

                MySqlCommand getLeaseCmd = new MySqlCommand(getLeaseQuery, conn);
                getLeaseCmd.Parameters.AddWithValue("@tenant_id", tenantId);

                object result = getLeaseCmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Tenant tidak memiliki lease aktif");
                    return;
                }

                int leaseId = Convert.ToInt32(result);
                DateTime dueDate = DateTime.Now.AddDays((int)numericUpDownDays.Value);

                string insertQuery = @"
            INSERT INTO transactions
            (lease_id, description, amount, payment_method, status, category, payment_due_by)
            VALUES
            (@lease_id, @description, @amount, @payment_method, 'Pending', 'damages', @due)
        ";

                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@lease_id", leaseId);
                cmd.Parameters.AddWithValue("@description", textBoxDescription.Text);
                cmd.Parameters.AddWithValue("@amount", numericUpDownAmount.Value);
                cmd.Parameters.AddWithValue("@payment_method", comboBoxPaymentMethod.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@due", dueDate);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Tagihan kerusakan berhasil ditambahkan");
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
