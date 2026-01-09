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
            if (tbNamaTamu.Text == "" || comboJamTamu.SelectedIndex < 0 || tbTujuanKunjungan.Text == "" || cbPersetujuan1.Checked == false || cbPersetujuan2.Checked == false)
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
        }

        void loadTagihan()
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT transaction_id, transaction_date as date, DATE_ADD(transaction_date, INTERVAL 3 DAY) as payment_due_by, category, description, amount, status FROM transactions WHERE lease_id IN (SELECT lease_id FROM leases WHERE tenant_id = @tenant_id)";
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

            decimal durationInput = numericUpDown1.Value; // Durasi tambahan (ekstensi)
            if (durationInput <= 0)
            {
                MessageBox.Show("Durasi harus minimal 1 bulan");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 2. Ambil data sewa saat ini (Harga, Tanggal Berakhir, dan Durasi Lama)
                decimal rentPrice = 0;
                DateTime previousEndDate = DateTime.Now;
                int currentDuration = 0; // Variabel untuk menampung durasi lama

                // Tambahkan kolom 'duration' (atau 'duration_months') ke dalam query SELECT
                string getLeaseQuery = "SELECT rent_price, end_date, duration_months FROM leases WHERE lease_id = @lease";

                using (MySqlCommand cmdFetch = new MySqlCommand(getLeaseQuery, conn))
                {
                    cmdFetch.Parameters.AddWithValue("@lease", lease_id);

                    using (MySqlDataReader reader = cmdFetch.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rentPrice = reader.GetDecimal("rent_price");
                            previousEndDate = reader.GetDateTime("end_date");
                            // Ambil durasi yang sekarang ada di database
                            currentDuration = reader.GetInt32("duration_months");
                        }
                        else
                        {
                            MessageBox.Show("Data sewa tidak ditemukan.");
                            return;
                        }
                    }
                }

                // 3. Kalkulasi Data Baru
                decimal totalAmount = rentPrice * durationInput;
                DateTime newEndDate = previousEndDate.AddMonths((int)durationInput);
                string paymentMethod = comboMetodePembayaran.Text;

                // Hitung total durasi baru (Durasi Awal + Durasi Perpanjangan)
                int newTotalDuration = currentDuration + (int)durationInput;

                // 4. Mulai Transaksi SQL
                MySqlTransaction sqlTrans = conn.BeginTransaction();

                try
                {
                    // --- STEP A: Insert ke tabel EXTENSIONS (Log History) ---
                    string insertExtQuery = @"
                    INSERT INTO extensions (lease_id, previous_end_date, new_end_date, duration_months, amount, payment_method, status, transaction_id) 
                    VALUES (@lease, @prevDate, @newDate, @durationAdd, @amount, @method, 'Approved', NULL)";

                    using (MySqlCommand cmdExt = new MySqlCommand(insertExtQuery, conn, sqlTrans))
                    {
                        cmdExt.Parameters.AddWithValue("@lease", lease_id);
                        cmdExt.Parameters.AddWithValue("@prevDate", previousEndDate);
                        cmdExt.Parameters.AddWithValue("@newDate", newEndDate);
                        cmdExt.Parameters.AddWithValue("@durationAdd", durationInput); // Masukkan hanya durasi tambahannya
                        cmdExt.Parameters.AddWithValue("@amount", totalAmount);
                        cmdExt.Parameters.AddWithValue("@method", paymentMethod);

                        cmdExt.ExecuteNonQuery();
                    }

                    // --- STEP B: Update tabel LEASES (Tanggal & Total Durasi) ---
                    // Update end_date DAN duration
                    string updateLeaseQuery = @"
                    UPDATE leases 
                    SET end_date = @newDate, 
                        duration_months = @totalDuration, 
                        status = 'Active' 
                    WHERE lease_id = @lease";

                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateLeaseQuery, conn, sqlTrans))
                    {
                        cmdUpdate.Parameters.AddWithValue("@newDate", newEndDate);
                        cmdUpdate.Parameters.AddWithValue("@totalDuration", newTotalDuration); // Masukkan total durasi baru
                        cmdUpdate.Parameters.AddWithValue("@lease", lease_id);

                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 5. Commit Transaksi
                    sqlTrans.Commit();
                    MessageBox.Show($"Perpanjangan berhasil disimpan.\nKontrak diperpanjang hingga: {newEndDate.ToString("dd MMMM yyyy")}\nTotal Durasi Sewa: {newTotalDuration} Bulan");

                    // this.Close(); 
                }
                catch (Exception ex)
                {
                    sqlTrans.Rollback();
                    MessageBox.Show("Gagal memperpanjang sewa: " + ex.Message);
                }
            }

            loadExtendData();
        }

        private void loadInfoLanjut()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    MessageBox.Show("loading...");
                    connection.Open();
                    string query = "SELECT\r\n    t.tenant_id,\r\n    t.full_name,\r\n    t.phone_number,\r\n\r\n    u.username,\r\n\r\n    r.room_number,\r\n    r.type AS room_type,\r\n    r.facilities,\r\n\r\n    l.start_date,\r\n    l.end_date,\r\n    l.duration_months,\r\n    l.rent_price,\r\n    l.rent_due,\r\n    l.status AS lease_status,\r\n\r\n    lb.bill_month,\r\n    lb.pemakaian_kwh,\r\n    lb.due_date AS expire_date\r\n\r\nFROM tenants t\r\nJOIN users u ON t.user_id = u.user_id\r\nJOIN leases l ON t.tenant_id = l.tenant_id\r\nJOIN rooms r ON l.room_id = r.room_id\r\nLEFT JOIN listrik_bills lb ON l.lease_id = lb.lease_id\r\nWHERE u.user_id = @id;\r\n";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id_user);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                lblInfoNama.Text = reader["full_name"].ToString();
                                lblInfoNotelp.Text = reader["phone_number"].ToString();
                                lblInfoNokamar.Text = reader["room_number"].ToString();
                                lblInfoTipekamar.Text = reader["room_type"].ToString();
                                lblInfoFasilitas.Text = reader["facilities"].ToString();
                                lblInfoTglmasuk.Text = reader["start_date"].ToString();
                                lblInfoTglkeluar.Text = reader["end_date"].ToString();
                                lblInfoDurasi.Text = reader["duration_months"].ToString() + " months";
                                lblInfoHargasewa.Text = "Rp " + reader["rent_price"].ToString();

                                lblInfoTglListirk.Text = reader["bill_month"].ToString();
                                lblInfoKWH.Text = reader["pemakaian_kwh"].ToString() + " kWh";
                                lblInfoTokenexp.Text = reader["expire_date"].ToString();
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
    }
}