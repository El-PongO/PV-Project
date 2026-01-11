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
    public partial class form_booked : Form
    {

        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        int tenant_id;
        public form_booked(DateTime tanggal, string kamar, string tipe, int tenant_id)
        {
            InitializeComponent();
            lblDurasiPenempatan.Text = tanggal.ToString("dd MMMM yyyy");
            lblKamar.Text = kamar;
            lblStatusPembayaran.Text = tipe;
            this.tenant_id = tenant_id;
            loadTagihan();
        }

        private void form_booked_Load(object sender, EventArgs e)
        {

        }



        void tagihanStyle()
        {
            // setting warna dkk
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(87, 216, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            // header
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 50;

            // row
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            dataGridView1.RowTemplate.Height = 45;

            // behaviour
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // nambah button kolom
            if (!dataGridView1.Columns.Contains("btnAction"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Action";
                btn.Name = "btnAction";
                btn.Text = "Action";
                btn.UseColumnTextForButtonValue = false;
                dataGridView1.Columns.Add(btn);
            }
            // nambah button kolom
            if (!dataGridView1.Columns.Contains("btnListrik"))
            {
                DataGridViewButtonColumn btnL = new DataGridViewButtonColumn();
                btnL.HeaderText = "Token Listrik";
                btnL.Name = "btnListrik";
                btnL.Text = "Token Listrik";
                btnL.UseColumnTextForButtonValue = false;
                dataGridView1.Columns.Add(btnL);
            }
        }

        void loadTagihan()
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string query = @"
                    SELECT 
                        t.transaction_id,
                        t.transaction_date AS DATE,
                        t.payment_due_by,
                        t.category,
                        t.description,
                        t.amount,
                        t.status
                    FROM transactions t
                    WHERE t.lease_id IN (
                        SELECT lease_id 
                        FROM leases 
                        WHERE tenant_id = @tenant_id
                    )
                    ORDER BY t.transaction_date DESC;
                    ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@tenant_id", tenant_id);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }



            }

            //hide si id
            dataGridView1.Columns["transaction_id"].Visible = false;
            //dataGridView1.Columns["listrik_bill_id"].Visible = false;
            tagihanStyle();


        }



        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnAction")
            {
                var row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["status"].Value != null)
                {
                    string status = row.Cells["status"].Value.ToString();

                    if (status == "Paid")
                    {
                        e.Value = "See Invoice";
                    }
                    else
                    {
                        e.Value = "Go Pay";
                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnListrik")
            {
                var row = dataGridView1.Rows[e.RowIndex];

                string category = row.Cells["category"].Value?.ToString();
                string status = row.Cells["status"].Value?.ToString();

                if (category == "electricity" && status == "Paid")
                {
                    e.Value = "Lihat Token Listrik";
                }
                else if (category == "electricity")
                {
                    e.Value = "Belum Dibayar";
                }
                else
                {
                    e.Value = "-";
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //click di button
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnAction")
            {
                string status = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();

                int transactionId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["transaction_id"].Value);

                if (status == "Paid")
                {
                    FormNota nota = new FormNota(transactionId);
                    nota.ShowDialog();
                }
                else
                {
                    payment pay = new payment(transactionId);
                    pay.ShowDialog();
                }
            }
            //click see token
            //if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnListrik")
            //{
            //    var row = dataGridView1.Rows[e.RowIndex];
            //    string category = dataGridView1.Rows[e.RowIndex]
            //    .Cells["category"].Value?.ToString();

            //    if (category != "electricity")
            //    {
            //        MessageBox.Show("Token listrik hanya tersedia untuk tagihan listrik.");
            //        return;
            //    }

            //    // hanya listrik paid
            //    if (row.Cells["status"].Value?.ToString() != "Paid")
            //    {
            //        MessageBox.Show("Tagihan listrik belum dibayar.");
            //        return;
            //    }

            //    int billId = 0;

            //    using (MySqlConnection conn = new MySqlConnection(connectionString))
            //    {
            //        conn.Open();
            //        string q = @"
            //            SELECT bill_id
            //            FROM listrik_bills
            //            WHERE lease_id = @lease
            //              AND status = 'Paid'
            //            ORDER BY bill_month DESC
            //            LIMIT 1;
            //        ";

            //        using (MySqlCommand cmd = new MySqlCommand(q, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@lease", lease_id);

            //            object result = cmd.ExecuteScalar();
            //            if (result == null)
            //            {
            //                MessageBox.Show("Token listrik belum tersedia.");
            //                return;
            //            }

            //            billId = Convert.ToInt32(result);
            //        }
            //    }


            //    formSeeTokenListrikUser form =
            //        new formSeeTokenListrikUser(billId, connectionString);

            //    form.ShowDialog();
            //}
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "btnListrik")
            //{
            //    var row = dataGridView1.Rows[e.RowIndex];

            //    // 1. Pastikan category listrik
            //    string category = row.Cells["category"].Value?.ToString();
            //    if (category != "electricity")
            //    {
            //        MessageBox.Show("Token listrik hanya tersedia untuk tagihan listrik.");
            //        return;
            //    }

            //    // 2. Pastikan sudah Paid
            //    if (row.Cells["status"].Value?.ToString() != "Paid")
            //    {
            //        MessageBox.Show("Tagihan listrik belum dibayar.");
            //        return;
            //    }

            //    // 3. Ambil bill_id LANGSUNG dari baris
            //    if (!int.TryParse(row.Cells["bill_id"].Value?.ToString(), out int billId))
            //    {
            //        MessageBox.Show("Token listrik belum tersedia.");
            //        return;
            //    }

            //    // 4. TEMBAK FORM DENGAN bill_id TERSEBUT
            //    formSeeTokenListrikUser form =
            //        new formSeeTokenListrikUser(billId, connectionString);

            //    form.ShowDialog();
            //}
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnListrik")
            {
                var row = dataGridView1.Rows[e.RowIndex];

                string category = row.Cells["category"].Value?.ToString();
                string status = row.Cells["status"].Value?.ToString();

                if (category != "electricity")
                {
                    MessageBox.Show("Token listrik hanya tersedia untuk tagihan listrik.");
                    return;
                }

                if (status != "Paid")
                {
                    MessageBox.Show("Tagihan listrik belum dibayar.");
                    return;
                }

                int transactionId = Convert.ToInt32(row.Cells["transaction_id"].Value);

                formSeeTokenListrikUser form =
                    new formSeeTokenListrikUser(transactionId, connectionString);

                form.ShowDialog();
            }


        }

    }
}
