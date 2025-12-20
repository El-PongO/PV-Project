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
    public partial class FormUser2 : Form
    {
        int id_user;
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        public FormUser2(int id)
        {
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

            //panel isi
            panelUserDashboard.Visible = true;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;

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

            //panel isi
            panelUserDashboard.Visible = true;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;

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

            //panel isi
            panelUserDashboard.Visible = false;
            panelExtendDuration.Visible = true;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = false;

            //ngeset
            panelExtendDuration.Location = new Point(230, 71);
            panelExtendDuration.Size = new Size(1000, 470);
            lblTitleHeader.Text = "Extend Duration";
        }
        private void NavBarUser_Complaint(object sender, EventArgs e)
        {
            //panel btn
            panelBtnDashboard.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtendDuration.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFileComplaint.BackColor = Color.Navy;
            panelBtnDaftarTamu.BackColor = Color.FromArgb(0, 0, 64);

            //panel isi
            panelUserDashboard.Visible = false;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = true;
            panelDaftarTamu.Visible = false;

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

            //panel isi
            panelUserDashboard.Visible = false;
            panelExtendDuration.Visible = false;
            panelUserComplaint.Visible = false;
            panelDaftarTamu.Visible = true;

            //ngeset
            panelDaftarTamu.Location = new Point(230, 71);
            panelDaftarTamu.Size = new Size(1000, 470);
            lblTitleHeader.Text = "Daftar Tamu Kamar";
        }

        private void StyleDgvNotif()
        {
            // 1. Basic Behavior (Read-Only)
            dgvNotifikasiBaru.ReadOnly = true;
            dgvNotifikasiBaru.AllowUserToAddRows = false;
            dgvNotifikasiBaru.AllowUserToDeleteRows = false;
            dgvNotifikasiBaru.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotifikasiBaru.MultiSelect = false;

            // 2. Remove the "Spreadsheet" Look
            dgvNotifikasiBaru.RowHeadersVisible = false;
            dgvNotifikasiBaru.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNotifikasiBaru.GridColor = Color.FromArgb(220, 220, 220);
            dgvNotifikasiBaru.BackgroundColor = Color.White;
            dgvNotifikasiBaru.BorderStyle = BorderStyle.None;

            // 3. Text Formatting (Crucial for Announcements)
            dgvNotifikasiBaru.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvNotifikasiBaru.DefaultCellStyle.Padding = new Padding(10);
            dgvNotifikasiBaru.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // WRAP TEXT
            dgvNotifikasiBaru.DefaultCellStyle.SelectionBackColor = Color.White; // Background stays White
            dgvNotifikasiBaru.DefaultCellStyle.SelectionForeColor = Color.Black; // Text stays Black

            // 4. Header Styling
            dgvNotifikasiBaru.EnableHeadersVisualStyles = false;
            dgvNotifikasiBaru.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvNotifikasiBaru.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvNotifikasiBaru.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNotifikasiBaru.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvNotifikasiBaru.ColumnHeadersHeight = 40;

            // 5. Auto-Sizing
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
                    string query = "SELECT u.user_id, u.username, t.tenant_id, t.full_name, r.room_number, r.type AS room_type, r.price, l.lease_id, l.start_date, l.end_date AS jatuh_tempo, DATEDIFF(l.end_date, CURRENT_DATE()) AS sisa_hari, l.status AS status_sewa FROM users u JOIN tenants t ON u.user_id = t.user_id JOIN leases l ON t.tenant_id = l.tenant_id JOIN rooms r ON l.room_id = r.room_id WHERE l.status = 'Active' AND u.user_id = @user";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection)){
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

                            }
                            else
                            {
                                MessageBox.Show("Something is wrong! Please reach out to our staff.");
                            }
                        }
                    }


                    //load data pengumuman
                    StyleDgvNotif();
                    query = "select title, content, created_at from announcements where is_active = 1";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNotifikasiBaru.DataSource = dt;
                    }
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }



            }

        }


    }
}
