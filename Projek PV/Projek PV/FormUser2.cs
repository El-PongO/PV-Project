using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projek_PV
{
    public partial class FormUser2 : Form
    {
        Form1 login;
        int lease_id;
        int id_user;
        int id_tenant;
        //string connectionString = "Server=172.20.10.5;Database=cozy_corner_db;Uid=root;Pwd=;";
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        public FormUser2(int id, Form1 master)
        {
            login = master;
            id_user = id;
            InitializeComponent();


        }
        private void FormUser2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1156, 579);

            lblTitleHeader.Text = "Main Page";
            panelUserDashboard.Visible = true;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;


            //awal buka dashboard jadi set navbar
            //panel btn
            panelBtnDashboard.BackColor = Color.Navy;
            panelBtnExtendDuration.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFileComplaint.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnDaftarTamu.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);


            //panel isi
            panelUserDashboard.Visible = true;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;
            panelTagihan.Visible = false;

            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panelInformasi.Visible = false;


            //ngeset
            panelUserDashboard.Location = new Point(230, 71);
            panelUserDashboard.Size = new Size(1000, 470);
            lblTitleHeader.Text = "User Dashboard";

            loadDashboardData();
        }

        private void NavBarUser_Dashboard(object sender, EventArgs e)
        {
            //panel btn
            panelBtnDashboard.BackColor = Color.Navy;
            panelBtnExtendDuration.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFileComplaint.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnDaftarTamu.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);


            //panel isi
            panelUserDashboard.Visible = true;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;
            panelTagihan.Visible = false;

            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panelInformasi.Visible = false;


            //ngeset
            panelUserDashboard.Location = new Point(230, 71);
            panelUserDashboard.Size = new Size(1000, 470);
            lblTitleHeader.Text = "User Dashboard";


            //backend
            loadDashboardData();
        }
        private void NavBarUser_ExtendDuration(object sender, EventArgs e)
        {
            //panel btn
            panelBtnDashboard.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtendDuration.BackColor = Color.Navy;
            panelBtnFileComplaint.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnDaftarTamu.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);


            //panel isi
            panelUserDashboard.Visible = false;
            panelExtendDuration.Visible = true;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;
            panelTagihan.Visible = false;

            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panelInformasi.Visible = false;


            //ngeset
            panelExtendDuration.Location = new Point(230, 71);
            panelExtendDuration.Size = new Size(1000, 470);
            lblTitleHeader.Text = "Extend Duration";




            //load data
            loadExtendData();

            numericUpDown1.Value = 1;
            comboMetodePembayaran.SelectedIndex = -1;



        }

        public void loadExtendData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    //load data umum user
                    string query = "SELECT * FROM leases l JOIN tenants t ON t.tenant_id = l.tenant_id JOIN users u ON u.user_id = t.user_id JOIN rooms r ON r.room_id = l.room_id WHERE u.user_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id_user);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                lblNoKamar.Text = reader["room_number"].ToString();
                                lblDurasiPenginapan.Text = reader["duration_months"].ToString();
                                lblJatuhTempoExt.Text = reader["end_date"].ToString();
                                lblVoucherAktif.Text = Convert.ToBoolean(reader["usingVoucher"]) ? "Yes" : "No";
                                id_tenant = Convert.ToInt32(reader["tenant_id"]);
                                
                                // Store lease_id for later use
                                lease_id = Convert.ToInt32(reader["lease_id"]);

                            }
                            else
                            {
                                MessageBox.Show("Something is wrong! Please reach out to our staff.");
                            }
                        }
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }



            }

        }
        private void NavBarUser_Complaint(object sender, EventArgs e)
        {
            //panel btn
            panelBtnDashboard.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtendDuration.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFileComplaint.BackColor = Color.Navy;
            panelBtnDaftarTamu.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);


            //panel isi
            panelUserDashboard.Visible = false;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = true;
            panelDaftarTamu.Visible = false;
            panelTagihan.Visible = false;

            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panelInformasi.Visible = false;


            //ngeset
            panelUserComplaint.Location = new Point(230, 71);
            panelUserComplaint.Size = new Size(1000, 470);
            lblTitleHeader.Text = "File a Complaint";
        }
        private void NavBarUser_DaftarTamu(object sender, EventArgs e)
        {
            //panel btn
            panelBtnDashboard.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtendDuration.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFileComplaint.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnDaftarTamu.BackColor = Color.Navy;
            panel3.BackColor = Color.FromArgb(0, 0, 64);


            //panel isi
            panelUserDashboard.Visible = false;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = true;
            panelTagihan.Visible = false;

            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panelInformasi.Visible = false;


            //ngeset
            panelDaftarTamu.Location = new Point(230, 71);
            panelDaftarTamu.Size = new Size(1000, 470);
            lblTitleHeader.Text = "Daftar Tamu Kamar";
        }

        private void NavBarUser_InformasiKamar(object sender, EventArgs e)
        {
            panelBtnDashboard.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtendDuration.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFileComplaint.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnDaftarTamu.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel2.BackColor = Color.Navy;

            panelUserDashboard.Visible = false;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;
            panelTagihan.Visible = false;
            panelInformasi.Visible = true;

            panelInformasi.Location = new Point(230, 71);
            panelInformasi.Size = new Size(908, 468);
            lblTitleHeader.Text = "Informasi Lanjut";

            loadInfoLanjut();

        }



        private void panel3_Click(object sender, EventArgs e)
        {
            //panel btn
            panelBtnDashboard.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtendDuration.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFileComplaint.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnDaftarTamu.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.Navy;


            //panel isi
            panelUserDashboard.Visible = false;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;
            panelTagihan.Visible = true;

            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panelInformasi.Visible = false;

            //ngeset
            panelTagihan.Location = new Point(230, 71);
            panelTagihan.Size = new Size(1000, 470);
            lblTitleHeader.Text = "Daftar Tagihan";


            //data
            loadTagihan();
        }

        private void StyleDgvNotif()
        {
            // read only setting
            dgvNotifikasiBaru.ReadOnly = true;
            dgvNotifikasiBaru.AllowUserToAddRows = false;
            dgvNotifikasiBaru.AllowUserToDeleteRows = false;
            dgvNotifikasiBaru.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotifikasiBaru.MultiSelect = false;

            // styling
            dgvNotifikasiBaru.RowHeadersVisible = false;
            dgvNotifikasiBaru.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNotifikasiBaru.GridColor = Color.FromArgb(220, 220, 220);
            dgvNotifikasiBaru.BackgroundColor = Color.White;
            dgvNotifikasiBaru.BorderStyle = BorderStyle.None;

            // text format
            dgvNotifikasiBaru.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvNotifikasiBaru.DefaultCellStyle.Padding = new Padding(10);
            dgvNotifikasiBaru.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // WRAP TEXT
            dgvNotifikasiBaru.DefaultCellStyle.SelectionBackColor = Color.White; // Background stays White
            dgvNotifikasiBaru.DefaultCellStyle.SelectionForeColor = Color.Black; // Text stays Black

            // header
            dgvNotifikasiBaru.EnableHeadersVisualStyles = false;
            dgvNotifikasiBaru.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvNotifikasiBaru.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvNotifikasiBaru.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNotifikasiBaru.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvNotifikasiBaru.ColumnHeadersHeight = 40;

            // Auto size
            dgvNotifikasiBaru.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotifikasiBaru.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        void loadDashboardData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    //load data umum user
                    string query = "SELECT u.user_id, u.username, t.tenant_id, t.full_name, r.room_number, r.type AS room_type, l.lease_id, l.start_date, l.end_date AS jatuh_tempo, DATEDIFF(l.end_date, CURRENT_DATE()) AS sisa_hari, l.status AS status_sewa FROM users u JOIN tenants t ON u.user_id = t.user_id JOIN leases l ON t.tenant_id = l.tenant_id JOIN rooms r ON l.room_id = r.room_id WHERE l.status = 'Active' AND u.user_id = @user";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@user", id_user);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                lblDurasiPenempatan.Text = reader["sisa_hari"].ToString() + " days left";
                                lblJatuhTempo.Text = reader["jatuh_tempo"].ToString();
                                lblStatusPembayaran.Text = reader["status_sewa"].ToString();
                                lblUserHeader.Text = reader["full_name"].ToString();
                                lease_id = Convert.ToInt32(reader["lease_id"]);
                                id_tenant = Convert.ToInt32(reader["tenant_id"]);

                            }
                            else
                            {
                                MessageBox.Show("Something is wrong! Please reach out to our staff.");
                            }
                        }
                    }


                    //load data pengumuman
                    StyleDgvNotif();
                    query = "SELECT title, content, created_at as time FROM announcements WHERE is_active = 1 UNION (SELECT CONCAT('Reply dari Complaints : ', category), admin_reply, reply_at as time FROM complaints WHERE tenant_id = @user AND admin_reply IS NOT NULL) union (SELECT title, content, created_at FROM reminders WHERE tenant_id = @tenant) order by time desc limit 10";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@user", id_user);
                        cmd.Parameters.AddWithValue("@tenant", id_tenant);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvNotifikasiBaru.DataSource = dt;
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }



            }

        }

        private void btnSubmitComplaint_Click(object sender, EventArgs e)
        {
            if (comboKategoriComplaint.SelectedIndex < 0 || tbDeskripsiComplaint.Text == "")
            {
                MessageBox.Show("Isi complain dulu");
            }
            else
            {
                string query = "INSERT INTO complaints(tenant_id, category, DESCRIPTION) VALUES(@user, @cat, @desc);";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", id_tenant);
                        cmd.Parameters.AddWithValue("@cat", comboKategoriComplaint.Text);
                        cmd.Parameters.AddWithValue("@desc", tbDeskripsiComplaint.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("complen created successfully!");
                        }
                        else
                        {
                            MessageBox.Show("complen failed.");
                        }
                    }
                }
                comboKategoriComplaint.SelectedIndex = -1;
                tbDeskripsiComplaint.Text = "";
            }

        }

        private void btnDaftarkanTamu_Click(object sender, EventArgs e)
        {
            if (tbNamaTamu.Text == "" || dateTimeKunjunganTamu.Value.Date < DateTime.Now.Date || comboJamTamu.SelectedIndex < 0 || tbTujuanKunjungan.Text == "" || cbPersetujuan1.Checked == false || cbPersetujuan2.Checked == false)
            {
                MessageBox.Show("Isi data tamu dengan benar!");
            }
            else
            {
                string query = "INSERT INTO guest_logs(tenant_id, guest_name, visit_date, arrival_time, purpose) VALUES(@user, @name, @date, @time, @purpose);";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", id_tenant);
                        cmd.Parameters.AddWithValue("@name", tbNamaTamu.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimeKunjunganTamu.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@time", comboJamTamu.Text);
                        cmd.Parameters.AddWithValue("@purpose", tbTujuanKunjungan.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tamu registered successfully!");
                            tbNamaTamu.Text = "";
                            comboJamTamu.SelectedIndex = -1;
                            tbTujuanKunjungan.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Tamu registration failed.");
                        }
                    }
                }
            }
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
                        cmd.Parameters.AddWithValue("@user", id_user);
                        cmd.Parameters.AddWithValue("@tenant_id", id_tenant);
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

        private void panelBtnLogout_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void panelBtnLogout_Paint(object sender, PaintEventArgs e)
        {

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

        private void lblVoucherAktif_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnPerpanjang_Click(object sender, EventArgs e)
        {
            if (comboMetodePembayaran.SelectedIndex < 0)
            {
                MessageBox.Show("Tolong isi credential terlebih dahulu");
                return;
            }

            decimal durationInput = numericUpDown1.Value;
            if (durationInput <= 0)
            {
                MessageBox.Show("Durasi harus minimal 1 bulan");
                return;
            }

            // ASK USER HOW THEY WANT TO PAY
            DialogResult paymentChoice = MessageBox.Show(
                "Cara pembayaran perpanjangan:\n\n" +
                "✓ YES: Bayar semua bulan sekaligus (IMMEDIATE)\n" +
                "✗ NO: Bayar per bulan (CONSECUTIVE)\n\n" +
                "Catatan: Jika pilih bayar per bulan, hanya bulan pertama yang ditagih sekarang. " +
                "Bulan berikutnya akan otomatis ditagih setiap bulan.",
                "",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (paymentChoice == DialogResult.Cancel)
            {
                return;
            }

            string newPaymentType = paymentChoice == DialogResult.Yes ? "IMMEDIATE" : "CONSECUTIVE";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                decimal rentPrice = 0;
                DateTime previousEndDate = DateTime.Now;
                int currentDuration = 0;
                string currentPaymentType = "IMMEDIATE";
                DateTime? currentRentDue = null;

                string getLeaseQuery = "SELECT rent_price, end_date, duration_months, payment_type, rent_due FROM leases WHERE lease_id = @lease";

                using (MySqlCommand cmdFetch = new MySqlCommand(getLeaseQuery, conn))
                {
                    cmdFetch.Parameters.AddWithValue("@lease", lease_id);

                    using (MySqlDataReader reader = cmdFetch.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rentPrice = reader.GetDecimal("rent_price");
                            previousEndDate = reader.GetDateTime("end_date");
                            currentDuration = reader.GetInt32("duration_months");
                            currentPaymentType = reader.GetString("payment_type");
                            
                            if (reader["rent_due"] != DBNull.Value)
                            {
                                currentRentDue = reader.GetDateTime("rent_due");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data sewa tidak ditemukan.");
                            return;
                        }
                    }
                }

                // Calculate amount
                decimal totalAmount = newPaymentType == "IMMEDIATE" 
                    ? rentPrice * durationInput 
                    : rentPrice;

                DateTime newEndDate = previousEndDate.AddMonths((int)durationInput);
                string paymentMethod = comboMetodePembayaran.Text;
                int newTotalDuration = currentDuration + (int)durationInput;

                MySqlTransaction sqlTrans = conn.BeginTransaction();

                try
                {
                    // STEP A: Insert extension record
                    string insertExtQuery = @"
                    INSERT INTO extensions (lease_id, previous_end_date, new_end_date, duration_months, amount, payment_method, status, transaction_id) 
                    VALUES (@lease, @prevDate, @newDate, @durationAdd, @amount, @method, 'Approved', NULL)";

                    using (MySqlCommand cmdExt = new MySqlCommand(insertExtQuery, conn, sqlTrans))
                    {
                        cmdExt.Parameters.AddWithValue("@lease", lease_id);
                        cmdExt.Parameters.AddWithValue("@prevDate", previousEndDate);
                        cmdExt.Parameters.AddWithValue("@newDate", newEndDate);
                        cmdExt.Parameters.AddWithValue("@durationAdd", durationInput);
                        cmdExt.Parameters.AddWithValue("@amount", totalAmount);
                        cmdExt.Parameters.AddWithValue("@method", paymentMethod);
                        cmdExt.ExecuteNonQuery();
                    }

                    // STEP B: Calculate new rent_due
                    DateTime? newRentDue = null;
                    
                    if (newPaymentType == "CONSECUTIVE")
                    {
                        // PRESERVE existing rent_due if user was on CONSECUTIVE and it's still active
                        if (currentPaymentType == "CONSECUTIVE" && 
                            currentRentDue.HasValue && 
                            currentRentDue.Value > DateTime.Now)
                        {
                            // The auto_update_rent_due_date event will advance it monthly
                            newRentDue = currentRentDue.Value;
                        }
                        else
                        {
                            // Start billing cycle 1 month from previous end date
                            newRentDue = previousEndDate.AddMonths(1);
                        }
                    }

                    // STEP C: Update lease
                    string updateLeaseQuery = @"
                    UPDATE leases 
                    SET end_date = @newDate, 
                        duration_months = @totalDuration, 
                        status = 'Active',
                        rent_due = @rentDue,
                        payment_type = @paymentType
                    WHERE lease_id = @lease";

                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateLeaseQuery, conn, sqlTrans))
                    {
                        cmdUpdate.Parameters.AddWithValue("@newDate", newEndDate);
                        cmdUpdate.Parameters.AddWithValue("@totalDuration", newTotalDuration);
                        cmdUpdate.Parameters.AddWithValue("@rentDue", newRentDue.HasValue ? (object)newRentDue.Value : DBNull.Value);
                        cmdUpdate.Parameters.AddWithValue("@paymentType", newPaymentType);
                        cmdUpdate.Parameters.AddWithValue("@lease", lease_id);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // STEP D: Insert transaction
                    string description = newPaymentType == "IMMEDIATE" 
                        ? $"Perpanjangan sewa {durationInput} bulan (Bayar Semua Sekaligus)" 
                        : $"Perpanjangan sewa - Pembayaran Bulan Pertama (dari {durationInput} bulan total)";

                    string insertTransQuery = @"
                    INSERT INTO transactions (lease_id, transaction_date, description, amount, payment_method, status, category)
                    VALUES (@lease, NOW(), @desc, @amount, @method, 'Pending', 'rent')";

                    using (MySqlCommand cmdTrans = new MySqlCommand(insertTransQuery, conn, sqlTrans))
                    {
                        cmdTrans.Parameters.AddWithValue("@lease", lease_id);
                        cmdTrans.Parameters.AddWithValue("@desc", description);
                        cmdTrans.Parameters.AddWithValue("@amount", totalAmount);
                        cmdTrans.Parameters.AddWithValue("@method", paymentMethod);
                        cmdTrans.ExecuteNonQuery();
                    }

                    sqlTrans.Commit();
                    
                    // Build success message
                    string message = "";
                    
                    if (newPaymentType == "IMMEDIATE")
                    {
                        message = $"✓ Perpanjangan Berhasil!\n\n" +
                                  $"Kontrak baru berakhir: {newEndDate:dd MMMM yyyy}\n" +
                                  $"Total durasi: {newTotalDuration} bulan\n" +
                                  $"Total dibayar: Rp {totalAmount:N0}\n\n" +
                                  $"Semua bulan sudah lunas.";
                    }
                    else // CONSECUTIVE
                    {
                        if (currentPaymentType == "CONSECUTIVE" && 
                            currentRentDue.HasValue && 
                            currentRentDue.Value > DateTime.Now)
                        {
                            message = $"✓ Perpanjangan Berhasil!\n\n" +
                                      $"Kontrak baru berakhir: {newEndDate:dd MMMM yyyy}\n" +
                                      $"Total durasi: {newTotalDuration} bulan\n" +
                                      $"Dibayar sekarang: Rp {totalAmount:N0}\n\n" +
                                      $"Tagihan bulanan tetap berjalan\n" +
                                      $"Tagihan berikutnya: {newRentDue.Value:dd MMMM yyyy}\n" +
                                      $"Rp {rentPrice:N0}/bulan hingga {newEndDate:dd MMMM yyyy}";
                        }
                        else
                        {
                            message = $"✓ Perpanjangan Berhasil!\n\n" +
                                      $"Kontrak baru berakhir: {newEndDate:dd MMMM yyyy}\n" +
                                      $"Total durasi: {newTotalDuration} bulan\n" +
                                      $"Dibayar sekarang: Rp {totalAmount:N0}\n\n" +
                                      $"Tagihan bulanan dimulai: {newRentDue.Value:dd MMMM yyyy}\n" +
                                      $"Rp {rentPrice:N0}/bulan hingga {newEndDate:dd MMMM yyyy}";
                        }
                    }
                    
                    MessageBox.Show(message, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    sqlTrans.Rollback();
                    MessageBox.Show("Gagal memperpanjang sewa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            loadExtendData();
            loadTagihan();
        }

        private void loadInfoLanjut()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT
                            t.tenant_id,
                            t.full_name,
                            t.phone_number,

                            u.username,

                            r.room_number,
                            r.type AS room_type,
                            r.facilities,

                            l.start_date,
                            l.end_date,
                            l.duration_months,
                            l.rent_price,
                            l.rent_due,
                            l.status AS lease_status,
                            l.payment_type,

                            lb.bill_month,
                            lb.pemakaian_kwh,
                            lb.due_date AS expire_date

                        FROM tenants t
                        JOIN users u ON t.user_id = u.user_id
                        JOIN leases l ON t.tenant_id = l.tenant_id
                        JOIN rooms r ON l.room_id = r.room_id
                        LEFT JOIN listrik_bills lb ON l.lease_id = lb.lease_id
                        WHERE u.user_id = @id AND l.status = 'Active'
                        ORDER BY lb.bill_month DESC
                        LIMIT 1;
                        ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id_user);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                lblInfoNama.Text = reader["full_name"].ToString();
                                lblInfoNotelp.Text = reader["phone_number"] != DBNull.Value ? reader["phone_number"].ToString() : "N/A";
                                lblInfoNokamar.Text = reader["room_number"].ToString();
                                lblInfoTipekamar.Text = reader["room_type"].ToString();
                                lblInfoFasilitas.Text = reader["facilities"].ToString();
                                lblInfoTglmasuk.Text = Convert.ToDateTime(reader["start_date"]).ToString("dd MMM yyyy");
                                lblInfoTglkeluar.Text = Convert.ToDateTime(reader["end_date"]).ToString("dd MMM yyyy");
                                lblInfoDurasi.Text = reader["duration_months"].ToString() + " months";
                                
                                // Format harga sewa dengan informasi payment type
                                decimal rentPrice = Convert.ToDecimal(reader["rent_price"]);
                                string paymentType = reader["payment_type"].ToString();
                                string paymentTypeText = paymentType == "IMMEDIATE" ? " (Bayar Semua)" : " (Per Bulan)";
                                lblInfoHargasewa.Text = "Rp " + rentPrice.ToString("N0") + paymentTypeText;

                                // Handle nullable fields for listrik
                                if (reader["bill_month"] != DBNull.Value)
                                {
                                    lblInfoTglListirk.Text = Convert.ToDateTime(reader["bill_month"]).ToString("MMMM yyyy");
                                    lblInfoKWH.Text = reader["pemakaian_kwh"].ToString() + " kWh";
                                    lblInfoTokenexp.Text = Convert.ToDateTime(reader["expire_date"]).ToString("dd MMM yyyy");
                                }
                                else
                                {
                                    lblInfoTglListirk.Text = "N/A";
                                    lblInfoKWH.Text = "N/A";
                                    lblInfoTokenexp.Text = "N/A";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Data tidak ditemukan atau status sewa tidak aktif.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            FormTagihListrikTenant form = new FormTagihListrikTenant(id_user, lease_id, connectionString);

            form.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LaporanAktif laporanAktif = new LaporanAktif(id_tenant);
            laporanAktif.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tamuTerdaftarUser tamuTerdaftarUser = new tamuTerdaftarUser(id_tenant);
            tamuTerdaftarUser.ShowDialog();
        }
    }
}