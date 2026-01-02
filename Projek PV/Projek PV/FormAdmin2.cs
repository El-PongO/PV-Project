using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;


namespace Projek_PV
{
    public partial class FormAdmin2 : Form
    {
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";
        private int selectedLeaseId = -1;
        public static int colscounter = 0;
        public static int rowscounter = 0;
        public int tenant_id = 0;
        public int roomNum = 0;
        public int roomId = 0;


        public FormAdmin2()
        {
            InitializeComponent();
            flowLayoutPanelKamar.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelKamar.WrapContents = true;
            flowLayoutPanelKamar.AutoScroll = true;
            flowLayoutPanelComplaints.AutoScroll = true;
            panelFill.AutoScroll = true;
            radioWanita1.Checked = true;
            radioWanita2.Checked = true;
        }

        private void FormAdmin2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1246, 900);

            panelOverview.Visible = true;
            panelManage.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelFill.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;

            panelOverview.Location = new Point(230, 82);
            panelOverview.Size = new Size(1000, 600);
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnManage.BringToFront();
            panelBtnFill.BringToFront();
            panelBtnOverview.BringToFront();
            panelBtnLaporan.BringToFront();
            panelBtnPenghuni.BringToFront();

            var roomTable = new DataTable();
            roomTable.Columns.Add("RoomCode", typeof(string));
            roomTable.Columns.Add("Occupied", typeof(bool));
            roomTable.Columns.Add("TenantName", typeof(string));
            roomTable.Columns.Add("RentDue", typeof(DateTime));

            roomTable.Rows.Add("A101", true, "John Doe", DateTime.Now.AddDays(7));
            roomTable.Rows.Add("A102", false, "", DBNull.Value);
            roomTable.Rows.Add("B201", true, "Jane Smith", DateTime.Now.AddDays(2));
            roomTable.Rows.Add("B202", false, "", DBNull.Value);
            roomTable.Rows.Add("C301", true, "Michael Brown", DateTime.Now.AddDays(15));

            dgvManage.DataSource = roomTable;

            dgvManage.Columns["RoomCode"].HeaderText = "Kode Ruangan";
            dgvManage.Columns["Occupied"].HeaderText = "Terisi";
            dgvManage.Columns["TenantName"].HeaderText = "Nama Penyewa";
            dgvManage.Columns["RentDue"].HeaderText = "Jatuh Tempo Sewa";
            dgvManage.Columns["Occupied"].Width = 60;

            panelFill.Location = new Point(238, -1);
            panelFill.Visible = false;
            loadComboBox();
            LoadDgvOverview();
            LoadDgvTagihan();
            updateOverview();
            loadDgvNotif();

        }

        

        private void NavBar_ManageRooms_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.Navy;
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            // panel isinya
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;

            if (roundedPanelOccupant1.Visible != true)
            {
                roundedPanelOccupant2.Visible = true;
            }
            else
            {
                roundedPanelOccupant2.Visible = false;
            }
            // ngeset
            panelManage.Location = new Point(230, 82);
            panelManage.Size = new Size(1000, 600);
            lblHeader.Text = "Manage Rooms";
        }
        private void NavBar_FillRoom_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.Navy;
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            // isinya panel
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            // nge set
            panelFill.Location = new Point(230, 82);
            panelFill.Size = new Size(1000, 600);
            lblHeader.Text = "Fill Room";
        }
        private void NavBar_Overview_Click(object sender, EventArgs e)
        {
            updateOverview();
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            // ini ngeset isinya panel
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            // nge set
            panelOverview.Location = new Point(230, 82);
            panelOverview.Size = new Size(1000, 600);
            lblHeader.Text = "Overview";
        }
        private void NavBar_Laporan_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.Navy;
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            // ini isinya panel 
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = true;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            // nge set
            flowLayoutPanelComplaints.Location = new Point(230, 82);
            flowLayoutPanelComplaints.Size = new Size(1000, 600);
            lblHeader.Text = "Laporan";
            LoadDataFromDatabase();
        }
        private void NavBar_PenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            // ini isinya panel nanti
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            flowLayoutPanelPendapatan.Visible = false;
            // nge set
            panelPenghunidanTagihan.Location = new Point(230, 82);
            panelPenghunidanTagihan.Size = new Size(1000, 600);
            lblHeader.Text = "Penghuni dan Tagihan";
        }
        private void NavBar_Kamar_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.Navy;
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            // ini buat tampilin isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = true;
            flowLayoutPanelPendapatan.Visible = false;
            // nge set
            flowLayoutPanelKamar.Location = new Point(230, 72);
            flowLayoutPanelKamar.Size = new Size(1000, 600);
            lblHeader.Text = "Kamar";
            LoadRoomCards();
        }
        private void NavBar_Extensions_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);

            // ini buat tampilin isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            // nge set
            lblHeader.Text = "Extensions";

        }

        private void NavBar_Pendapatan_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.Navy;

            // content
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = true;

            flowLayoutPanelPendapatan.Location = new Point(230, 82);
            flowLayoutPanelPendapatan.Size = new Size(1000, 600);
            lblHeader.Text = "Laporan Pendapatan";
            LoadPendapatanFromDatabase();
        }
        private void CreateRoomCard(DataRow row)
        {
            // MAIN CARD PANEL
            RoundedPanel card = new RoundedPanel();
            card.Width = 307;
            card.Height = 210;
            //card.BackColor = Color.White;
            card.Margin = new Padding(10);
            card.BorderColor = SystemColors.Control;

            // ROOM NAME
            Label lblName = new Label();
            lblName.Text = row["RoomName"].ToString();
            lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblName.Location = new Point(10, 10);
            lblName.AutoSize = true;
            card.Controls.Add(lblName);

            // ROOM TYPE
            Label lblType = new Label();
            lblType.Text = row["RoomType"].ToString();
            lblType.Font = new Font("Segoe UI", 10);
            lblType.ForeColor = Color.DimGray;
            lblType.Location = new Point(10, 45);
            lblType.AutoSize = true;
            card.Controls.Add(lblType);

            // PRICE
            Label lblPrice = new Label();
            decimal price = Convert.ToDecimal(row["Price"]);
            lblPrice.Text = "Rp " + price.ToString("N0");
            lblPrice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPrice.Location = new Point(10, 75);
            lblPrice.AutoSize = true;
            card.Controls.Add(lblPrice);

            // STATUS BADGE
            Label lblStatus = new Label();
            lblStatus.Text = row["Status"].ToString();
            lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.AutoSize = true;
            lblStatus.Padding = new Padding(6);

            lblStatus.Location = new Point(card.Width - 100, 10);

            if (lblStatus.Text == "Tersedia")
                lblStatus.BackColor = Color.FromArgb(80, 200, 120); // green
            else
                lblStatus.BackColor = Color.FromArgb(220, 80, 80); // red

            lblStatus.ForeColor = Color.White;
            card.Controls.Add(lblStatus);

            // FACILITIES PANEL
            FlowLayoutPanel facilitiesPanel = new FlowLayoutPanel();
            facilitiesPanel.Location = new Point(10, 110);
            facilitiesPanel.Width = card.Width - 20;
            facilitiesPanel.Height = 60;
            facilitiesPanel.AutoSize = false;
            facilitiesPanel.WrapContents = true;
            facilitiesPanel.FlowDirection = FlowDirection.LeftToRight;

            string[] facilities = row["Facilities"].ToString().Split(',');

            foreach (string f in facilities)
            {
                RoundedPanel chip = new RoundedPanel();
                chip.BorderRadius = 8;
                chip.BorderSize = 0;
                chip.FillColor = Color.Gainsboro;
                chip.Padding = new Padding(8, 4, 8, 4);
                chip.Margin = new Padding(4);
                chip.AutoSize = true;
                chip.MinimumSize = new Size(30, 23);
                chip.Padding = new Padding(8, 4, 8, 4);


                // TEXT inside chip
                Label lbl = new Label();
                lbl.Text = f.Trim();
                lbl.AutoSize = true;
                lbl.BackColor = Color.Transparent;
                lbl.Font = new Font("Segoe UI", 9);

                chip.Controls.Add(lbl);

                chip.SizeChanged += (s, e) =>
                {
                    lbl.Location = new Point(
                        (chip.Width - lbl.Width) / 2,
                        (chip.Height - lbl.Height) / 2
                    );
                };

                facilitiesPanel.Controls.Add(chip);

            }


            card.Controls.Add(facilitiesPanel);
            card.AutoScroll = true;

            // EDIT BUTTON
            Button btnEdit = new Button();
            btnEdit.Text = "Edit";
            btnEdit.Width = 80;
            btnEdit.Height = 35;
            btnEdit.Location = new Point(card.Width - 100, card.Height - 50);

            // GET ROOM NUMBER (IMPORTANT)
            string roomNumber = row["RoomName"].ToString().Replace("Kamar ", "");

            // CLICK EVENT
            btnEdit.Click += (s, e) =>
            {
                EditDetailRoom form = new EditDetailRoom(roomNumber, connectionString);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadRoomCards(); // 🔄 refresh cards after save
                }
            };

            card.Controls.Add(btnEdit);

            flowLayoutPanelKamar.Controls.Add(card);
        }
        private DataTable GetRoomData()
        {
            DataTable dt = new DataTable();

            // Columns expected by CreateRoomCard
            dt.Columns.Add("RoomName");
            dt.Columns.Add("RoomType");
            dt.Columns.Add("Price");
            dt.Columns.Add("Status");
            dt.Columns.Add("Facilities");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = " SELECT room_number,type,base_price,status,IFNULL(facilities, '') AS facilities FROM rooms ORDER BY room_number";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                "Kamar " + reader["room_number"].ToString(), // RoomName
                                reader["type"].ToString(),                   // RoomType
                                reader["base_price"].ToString(),             // Price
                                reader["status"].ToString(),                 // Status
                                reader["facilities"].ToString()              // Facilities
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading room data: " + ex.Message);
                }
            }

            return dt;
        }


        private void LoadRoomCards()
        {
            DataTable dt = GetRoomData(); // generate sample data

            // Clear existing cards so repeated calls don't duplicate
            if (flowLayoutPanelKamar.Controls.Count > 0)
                flowLayoutPanelKamar.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                CreateRoomCard(row);
            }
        }

        private void LoadDgvOverview()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT r.room_number,r.type,t.full_name FROM leases l JOIN rooms r ON r.room_id = l.room_id JOIN tenants t ON l.tenant_id = t.tenant_id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvManage.DataSource = dt;
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

        private void LoadDgvTagihan()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT \r\n    l.lease_id,\r\n    t.tenant_id,\r\n    t.full_name AS nama_penghuni,\r\n    r.room_number AS kamar,\r\n    l.start_date AS tgl_masuk,\r\n    MAX(tr.transaction_date) AS tagihan_terakhir,\r\n    CASE\r\n        WHEN l.status = 'Active' THEN 'AKTIF'\r\n        ELSE 'MENUNGGAK'\r\n    END AS STATUS\r\nFROM tenants t\r\nJOIN leases l ON t.tenant_id = l.tenant_id\r\nJOIN rooms r ON l.room_id = r.room_id\r\nLEFT JOIN transactions tr \r\n    ON tr.lease_id = l.lease_id \r\n    AND tr.status = 'Paid'\r\nGROUP BY \r\n    l.lease_id,\r\n    t.tenant_id,\r\n    t.full_name,\r\n    r.room_number,\r\n    l.start_date,\r\n    l.status\r\nORDER BY t.full_name;\r\n";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTagihan.DataSource = dt;
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

        private void CreateComplaintCard(int id, string category, string nama, string kamar, string tanggal, string pesan, string status)
        {
            // MAIN CARD
            RoundedPanel card = new RoundedPanel();
            card.Width = 850;
            card.Height = 210;
            card.BorderRadius = 20;
            card.BorderSize = 0;
            card.FillColor = Color.White;
            card.Margin = new Padding(15);

            // TITLE
            Label lblTitle = new Label();
            lblTitle.Text = category;
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            // SUBTITLE
            Label lblSub = new Label();
            lblSub.Text = $"{nama} · {kamar} · {tanggal}";
            lblSub.Font = new Font("Segoe UI", 9);
            lblSub.ForeColor = Color.Gray;
            lblSub.Location = new Point(20, 40);
            lblSub.AutoSize = true;
            card.Controls.Add(lblSub);

            // STATUS (Rounded)
            RoundedPanel statusPanel = new RoundedPanel();
            statusPanel.Width = 120;
            statusPanel.Height = 32;
            statusPanel.BorderRadius = 12;
            statusPanel.BorderSize = 0;
            statusPanel.FillColor = Color.FromArgb(255, 220, 220);
            statusPanel.Location = new Point(card.Width - 150, 20);

            ComboBox cmbStatus = new ComboBox();
            cmbStatus.Dock = DockStyle.Fill;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new string[] { "Menunggu", "Proses", "Selesai" });
            int statusIndex = cmbStatus.FindStringExact(status);
            cmbStatus.SelectedIndex = (statusIndex != -1) ? statusIndex : 0;
            if (status == "Selesai")
            {
                statusPanel.FillColor = Color.FromArgb(200, 255, 200);
                cmbStatus.ForeColor = Color.DarkGreen;
            }
            else if (status == "Proses")
            {
                statusPanel.FillColor = Color.FromArgb(255, 250, 200);
                cmbStatus.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                statusPanel.FillColor = Color.FromArgb(255, 220, 220);
                cmbStatus.ForeColor = Color.DarkRed;
            }
            cmbStatus.BackColor = statusPanel.FillColor;
            statusPanel.Controls.Add(cmbStatus);
            card.Controls.Add(statusPanel);

            // MESSAGE BUBBLE
            RoundedPanel msgPanel = new RoundedPanel();
            msgPanel.Width = card.Width - 40;
            msgPanel.Height = 45;
            msgPanel.Location = new Point(20, 70);
            msgPanel.BorderRadius = 12;
            msgPanel.BorderSize = 0;
            msgPanel.FillColor = Color.FromArgb(245, 245, 245);

            Label lblMsg = new Label();
            lblMsg.Text = pesan;
            lblMsg.Font = new Font("Segoe UI", 9);
            lblMsg.ForeColor = Color.Black;
            lblMsg.AutoSize = false;
            lblMsg.Dock = DockStyle.Fill;
            lblMsg.Padding = new Padding(10);

            msgPanel.Controls.Add(lblMsg);
            card.Controls.Add(msgPanel);

            // REPLY BOX
            RoundedPanel replyPanel = new RoundedPanel();
            replyPanel.Width = card.Width - 80;
            replyPanel.Height = 40;
            replyPanel.Location = new Point(20, 130);
            replyPanel.BorderRadius = 12;
            replyPanel.BorderSize = 0;
            replyPanel.FillColor = Color.FromArgb(50, 50, 50);

            TextBox txtReply = new TextBox();
            txtReply.BorderStyle = BorderStyle.None;
            txtReply.Multiline = true;
            txtReply.Dock = DockStyle.Fill;
            txtReply.ForeColor = Color.White;
            txtReply.BackColor = replyPanel.FillColor;
            txtReply.Font = new Font("Segoe UI", 9);
            //txtReply.Text = "Balasan admin...";
            txtReply.Padding = new Padding(8);

            replyPanel.Controls.Add(txtReply);
            card.Controls.Add(replyPanel);

            // SEND BUTTON
            Button btnSend = new Button();
            btnSend.Text = "➤";
            btnSend.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSend.Width = 40;
            btnSend.Height = 40;
            btnSend.Location = new Point(card.Width - 50, 130);
            btnSend.BackColor = Color.FromArgb(60, 120, 255);
            btnSend.ForeColor = Color.White;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.FlatAppearance.BorderSize = 0;



            btnSend.Click += (sender, e) =>
            {

                if (txtReply.Text == "")
                {
                    MessageBox.Show("Harap isi pesan balasan.");
                    return;
                }


                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateSql = "UPDATE complaints SET status = @status, admin_reply = @response, reply_at = @time WHERE complaint_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem);
                        cmd.Parameters.AddWithValue("@response", txtReply.Text);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@time", DateTime.Now);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Balasan terkirim dan status diperbarui.");
                            flowLayoutPanelComplaints.Controls.Remove(card);
                            LoadDataFromDatabase(); 
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengirim balasan. Silakan coba lagi.");
                        }
                    }
                }
            };



            card.Controls.Add(btnSend);

            flowLayoutPanelComplaints.Controls.Add(card);
        }

        private void CreatePendapatanCard(int id, string nama, string sumber, decimal jumlah, string metode, string tanggal, string status, string notes)
        {
            RoundedPanel card = new RoundedPanel();
            card.Width = 850;
            card.Height = 200;
            card.BorderRadius = 20;
            card.BorderSize = 0;
            card.FillColor = Color.White;
            card.Margin = new Padding(15);

            // TITLE
            Label lblTitle = new Label();
            lblTitle.Text = $"{nama} · {sumber}";
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            // SUBTITLE
            Label lblSub = new Label();
            lblSub.Text = $"{tanggal} · {metode}";
            lblSub.Font = new Font("Segoe UI", 9);
            lblSub.ForeColor = Color.Gray;
            lblSub.Location = new Point(20, 40);
            lblSub.AutoSize = true;
            card.Controls.Add(lblSub);

            // AMOUNT
            Label lblAmount = new Label();
            lblAmount.Text = "Rp " + Convert.ToInt32(jumlah).ToString("N0");
            lblAmount.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblAmount.ForeColor = Color.Black;
            lblAmount.Location = new Point(20, 70);
            lblAmount.AutoSize = true;
            card.Controls.Add(lblAmount);

            // STATUS PANEL
            RoundedPanel statusPanel = new RoundedPanel();
            statusPanel.Width = 150;
            statusPanel.Height = 32;
            statusPanel.BorderRadius = 12;
            statusPanel.BorderSize = 0;
            statusPanel.Location = new Point(card.Width - 180, 15);

            ComboBox cmbStatus = new ComboBox();
            cmbStatus.Dock = DockStyle.Fill;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new string[] { "Pending", "Confirmed", "Cancelled" });
            int sIdx = cmbStatus.FindStringExact(status);
            cmbStatus.SelectedIndex = (sIdx != -1) ? sIdx : 0;

            Color fill;
            Color textColor;
            if (cmbStatus.SelectedItem.ToString() == "Confirmed") { fill = Color.FromArgb(200, 255, 200); textColor = Color.DarkGreen; }
            else if (cmbStatus.SelectedItem.ToString() == "Pending") { fill = Color.FromArgb(255, 250, 200); textColor = Color.DarkGoldenrod; }
            else { fill = Color.FromArgb(255, 220, 220); textColor = Color.DarkRed; }
            statusPanel.FillColor = fill;
            cmbStatus.ForeColor = textColor;
            cmbStatus.BackColor = fill;
            statusPanel.Controls.Add(cmbStatus);
            card.Controls.Add(statusPanel);

            // NOTES PANEL
            RoundedPanel notesPanel = new RoundedPanel();
            notesPanel.Width = card.Width - 40;
            notesPanel.Height = 45;
            notesPanel.Location = new Point(20, 105);
            notesPanel.BorderRadius = 12;
            notesPanel.BorderSize = 0;
            notesPanel.FillColor = Color.FromArgb(245, 245, 245);

            Label lblNotes = new Label();
            lblNotes.Text = notes ?? "";
            lblNotes.Font = new Font("Segoe UI", 9);
            lblNotes.ForeColor = Color.Black;
            lblNotes.AutoSize = false;
            lblNotes.Dock = DockStyle.Fill;
            lblNotes.Padding = new Padding(10);

            notesPanel.Controls.Add(lblNotes);
            card.Controls.Add(notesPanel);

            // UPDATE BUTTON
            Button btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnUpdate.Width = 90;
            btnUpdate.Height = 32;
            btnUpdate.Location = new Point(card.Width - 110, 155);
            btnUpdate.BackColor = Color.FromArgb(60, 120, 255);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderSize = 0;

            btnUpdate.Click += (sender, e) =>
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateSql = "UPDATE pendapatan SET status = @status WHERE pendapatan_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem);
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Status pendapatan diperbarui.");
                            flowLayoutPanelPendapatan.Controls.Remove(card);
                            LoadPendapatanFromDatabase();
                        }
                        else
                        {
                            MessageBox.Show("Gagal memperbarui status.");
                        }
                    }
                }
            };

            card.Controls.Add(btnUpdate);

            flowLayoutPanelPendapatan.Controls.Add(card);
        }

        public DataTable GetData(string query)
        {
            string connString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Database: " + ex.Message);
                }
            }
            return dt;
        }

        private void LoadDataFromDatabase()
        {

            flowLayoutPanelComplaints.Controls.Clear();

            string query = "SELECT c.complaint_id,c.category,t.full_name,r.room_number,c.created_at,c.description,c.status FROM complaints c JOIN tenants t ON c.tenant_id = t.tenant_id JOIN leases l ON c.tenant_id = l.tenant_id JOIN rooms r ON l.room_id = r.room_id WHERE c.status <> 'Selesai' ";

            DataTable dt = GetData(query);

            foreach (DataRow row in dt.Rows)
            {
                CreateComplaintCard(
                    Convert.ToInt32(row["complaint_id"]),
                    row["category"].ToString(),
                    row["full_name"].ToString(),
                    row["room_number"].ToString(),
                    row["created_at"].ToString(),
                    row["description"].ToString(),
                    row["status"].ToString()
                );
            }
        }

        private void LoadPendapatanFromDatabase()
        {
            flowLayoutPanelPendapatan.Controls.Clear();
            string query = @"SELECT p.pendapatan_id, t.full_name, p.source, p.amount, p.payment_method, p.paid_at, p.status, p.notes
                              FROM pendapatan p
                              JOIN tenants t ON p.tenant_id = t.tenant_id
                              LEFT JOIN leases l ON p.lease_id = l.lease_id";

            DataTable dt = GetData(query);
            foreach (DataRow row in dt.Rows)
            {
                CreatePendapatanCard(
                    Convert.ToInt32(row["pendapatan_id"]),
                    row["full_name"].ToString(),
                    row["source"].ToString(),
                    row["amount"] != DBNull.Value ? Convert.ToDecimal(row["amount"]) : 0,
                    row["payment_method"].ToString(),
                    row["paid_at"].ToString(),
                    row["status"].ToString(),
                    row.Table.Columns.Contains("notes") ? row["notes"].ToString() : string.Empty
                );
            }
        }

        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadComboBox()
        {
            string query = "SELECT * FROM rooms WHERE STATUS = 'Tersedia' ";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // 2. Gunakan MySqlDataAdapter untuk mengisi DataTable
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 3. Masukkan data ke ComboBox
                    comboRoomFill.DataSource = dt;


                    comboRoomFill.DisplayMember = "room_number";


                    comboRoomFill.ValueMember = "room_id";

                    comboRoomFill.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitFill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNama1.Text) || comboRoomFill.SelectedValue == null)
            {
                MessageBox.Show("Isi Data Terlebih Dahulu");
                return;
            }

            decimal hargaKamar = 0;
            string gender = radioWanita1.Checked ? "Perempuan" : "Laki-Laki";
            int tenantCount = checkBox4.Checked ? 2 : 1;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // STEP A: Ambil harga dulu (Boleh di luar transaksi karena hanya SELECT)
                    string queryHarga = "SELECT base_price FROM rooms WHERE room_id = @roomNum";
                    using (MySqlCommand cmdHarga = new MySqlCommand(queryHarga, conn))
                    {
                        cmdHarga.Parameters.AddWithValue("@roomNum", comboRoomFill.SelectedValue);
                        object res = cmdHarga.ExecuteScalar();
                        hargaKamar = (res != null && res != DBNull.Value) ? Convert.ToDecimal(res) : 0;
                    }

                    // Hitung kenaikan harga jika ada tenant tambahan (30%)
                    if (checkBox4.Checked) { hargaKamar += hargaKamar * 0.3m; }

                    // STEP B: Mulai Transaksi untuk INSERT/UPDATE
                    using (MySqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insert User
                            long userId;
                            string qUser = "INSERT INTO users(username,password) VALUES(@user,@pass);";
                            using (MySqlCommand c1 = new MySqlCommand(qUser, conn, tr))
                            {
                                c1.Parameters.AddWithValue("@user", tbNama1.Text);
                                c1.Parameters.AddWithValue("@pass", "123");
                                c1.ExecuteNonQuery();
                                userId = c1.LastInsertedId;
                            }

                            // 2. Insert Tenant Utama
                            long mainTenantId;
                            string qTenant = @"INSERT INTO tenants(user_id, full_name, ktp_number, gender, date_of_birth, address) 
                                       VALUES(@uId, @name, @ktp, @gen, @date, @addr);";
                            using (MySqlCommand c2 = new MySqlCommand(qTenant, conn, tr))
                            {
                                c2.Parameters.AddWithValue("@uId", userId);
                                c2.Parameters.AddWithValue("@name", tbNama1.Text);
                                c2.Parameters.AddWithValue("@ktp", tbNIK1.Text);
                                c2.Parameters.AddWithValue("@gen", gender);
                                c2.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                                c2.Parameters.AddWithValue("@addr", tbAlamat1.Text);
                                c2.ExecuteNonQuery();
                                mainTenantId = c2.LastInsertedId; // Ambil ID SETELAH Execute
                            }

                            // 3. Insert Tenant Tambahan (Jika ada)
                            if (checkBox4.Checked)
                            {
                                using (MySqlCommand c2b = new MySqlCommand(qTenant, conn, tr))
                                {
                                    c2b.Parameters.AddWithValue("@uId", userId);
                                    c2b.Parameters.AddWithValue("@name", tbNama2.Text);
                                    c2b.Parameters.AddWithValue("@ktp", tbNIK2.Text);
                                    c2b.Parameters.AddWithValue("@gen", radioWanita2.Checked ? "Perempuan" : "Laki-Laki");
                                    c2b.Parameters.AddWithValue("@date", dateTimePicker2.Value);
                                    c2b.Parameters.AddWithValue("@addr", tbAlamat2.Text);
                                    c2b.ExecuteNonQuery();
                                }
                            }

                            // 4. Insert Lease (PASTIKAN NAMA TABEL BENAR: leases)
                            string qLease = @"INSERT INTO leases(room_id, tenant_id, tenant_count, rent_price, start_date, end_date, duration_months) 
                                      VALUES(@rId, @tId, @tCount, @rent, @start, @end, @dur);";
                            using (MySqlCommand c3 = new MySqlCommand(qLease, conn, tr))
                            {
                                DateTime start = DateTime.Now;
                                c3.Parameters.AddWithValue("@rId", comboRoomFill.SelectedValue);
                                c3.Parameters.AddWithValue("@tId", mainTenantId);
                                c3.Parameters.AddWithValue("@tCount", tenantCount);
                                c3.Parameters.AddWithValue("@rent", hargaKamar);
                                c3.Parameters.AddWithValue("@start", start);
                                c3.Parameters.AddWithValue("@end", start.AddMonths(6));
                                c3.Parameters.AddWithValue("@dur", 6);
                                c3.ExecuteNonQuery();
                            }

                            // 5. Update Status Kamar
                            string qUpd = "UPDATE rooms SET status = 'Terisi' WHERE room_id = @rId";
                            using (MySqlCommand c4 = new MySqlCommand(qUpd, conn, tr))
                            {
                                c4.Parameters.AddWithValue("@rId", comboRoomFill.SelectedValue);
                                c4.ExecuteNonQuery();
                            }

                            // AKHIR: Hanya satu commit untuk semua query di atas
                            tr.Commit();
                            MessageBox.Show("Seluruh data berhasil disimpan dan kamar telah terupdate!");
                            loadComboBox();
                            LoadDgvOverview();
                            LoadDgvTagihan();
                            reset();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            MessageBox.Show("Transaksi Gagal (Rollback): " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                gbOccupant2Fill.Enabled = true;
            }
            else
            {
                gbOccupant2Fill.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            gbOccupant2Fill.Enabled = false;
        }

        private void reset()
        {
            tbNama1.Text = "";
            tbNIK1.Text = "";
            tbAlamat1.Text = "";
            tbNama2.Text = "";
            tbNIK2.Text = "";
            tbAlamat2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            radioWanita1.Checked = true;
            radioWanita2.Checked = true;
            checkBox4.Checked = false;
            checkBox2.Checked = false;
            comboRoomFill.SelectedIndex = -1;
        }

        private void comboRoomFill_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanelLaporan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateOverview()
        {
            string terisi1 = "";
            string kosong1 = "";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string orang = "SELECT COUNT(lease_id) FROM leases WHERE STATUS = 'Active' ";
                    using (MySqlCommand cmd = new MySqlCommand(orang, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        label44.Text = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string complain = "SELECT COUNT(complaint_id) FROM complaints WHERE STATUS = 'Menunggu' ";
                    using (MySqlCommand cmd = new MySqlCommand(complain, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        label46.Text = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string kamar = "SELECT COUNT(room_id) FROM rooms ";
                    using (MySqlCommand cmd = new MySqlCommand(kamar, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        label40.Text = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string terisi = "SELECT COUNT(room_id) FROM rooms WHERE STATUS = 'Terisi' ";
                    using (MySqlCommand cmd = new MySqlCommand(terisi, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        terisi1 = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string kosong = "SELECT COUNT(room_id) FROM rooms WHERE STATUS = 'Tersedia' ";
                    using (MySqlCommand cmd = new MySqlCommand(kosong, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        kosong1 = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";
                        label39.Text = terisi1.ToString() + " Terisi / " + kosong1.ToString() + " Kosong";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        private void GetDataByFullName(string name)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tenants t JOIN leases l ON t.tenant_id = l.tenant_id WHERE t.full_name = @name";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        namaHuni1.Text = row["full_name"].ToString();
                        ktpHuni1.Text = row["ktp_number"].ToString();

                        if (row["date_of_birth"] != DBNull.Value)
                            tglHuni1.Text = Convert.ToDateTime(row["date_of_birth"]).ToString("dd MMM yyyy");

                        genderHuni1.Text = row["gender"].ToString();
                        lblDuration.Text = row["duration_months"].ToString() + " Months";

                        if (row["start_date"] != DBNull.Value)
                            lblSince.Text = Convert.ToDateTime(row["start_date"]).ToString("dd/MM/yyyy");

                        if (Convert.ToInt32(row["tenant_count"]) == 2)
                        {
                            roundedPanelOccupant2.Visible = true;
                            GetSecondTenant(row["user_id"].ToString(), row["full_name"].ToString());
                        }
                        else
                        {
                            roundedPanelOccupant2.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void GetSecondTenant(string userId, string excludedName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tenants WHERE user_id = @uid AND full_name <> @excludedName LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@excludedName", excludedName);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row2 = dt.Rows[0];
                        namaHuni2.Text = row2["full_name"].ToString();
                        ktpHuni2.Text = row2["ktp_number"].ToString();

                        if (row2["date_of_birth"] != DBNull.Value)
                            tglHuni2.Text = Convert.ToDateTime(row2["date_of_birth"]).ToString("dd MMM yyyy");

                        genderHuni2.Text = row2["gender"].ToString();
                    }
                    else
                    {
                        roundedPanelOccupant2.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void GetRoomIdByNumber(int roomNumber)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT room_id FROM rooms WHERE room_number = @roomNumber";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@roomNumber", roomNumber);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        roomId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    private void loadDgvNotif()
        {
            string query = "SELECT title, content FROM announcements LIMIT 5";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvNotification.DataSource = dt;
                    dgvNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    private void dgvManage_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                    roundedPanelOccupant2.Visible = false;
                    if (e.RowIndex >= 0)
                    {
                        string fullName = dgvManage.Rows[e.RowIndex].Cells[2].Value.ToString();
                        GetDataByFullName(fullName);
                        roomNum = Convert.ToInt32(dgvManage.Rows[e.RowIndex].Cells[0].Value);
                    }
            }

        private void btnUnoccupy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus data sewa dan ubah status kamar menjadi Tersedia?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        MySqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string queryUpdate = "UPDATE rooms SET status = 'Tersedia' WHERE room_number = @room_id";
                            MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn, transaction);
                            cmdUpdate.Parameters.AddWithValue("@room_id", roomNum);
                            cmdUpdate.ExecuteNonQuery();

                            GetRoomIdByNumber(roomNum);
                            string queryDelete = "DELETE FROM leases WHERE room_id = @room_id";
                            MySqlCommand cmdDelete = new MySqlCommand(queryDelete, conn, transaction);
                            cmdDelete.Parameters.AddWithValue("@room_id", roomId);
                            cmdDelete.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Proses berhasil dilakukan.");
                            LoadDgvOverview();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Transaksi gagal: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Koneksi: " + ex.Message);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void buttonTagihListrikTenant_Click(object sender, EventArgs e)
        {
            if (dgvTagihan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih tenant terlebih dahulu!");
                return;
            }

            DataGridViewRow row = dgvTagihan.SelectedRows[0];

            int tenantId = Convert.ToInt32(row.Cells["tenant_id"].Value);
            int leaseId = Convert.ToInt32(row.Cells["lease_id"].Value);

            FormTagihListrikTenant form = new FormTagihListrikTenant(tenantId, leaseId, connectionString);

            form.ShowDialog();

        }

        private void dgvTagihan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void dgvTagihan_DoubleClick(object sender, EventArgs e)
        {
            // this is buat nyetak nota per orang
        }

        private void dgvTagihan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedLeaseId = Convert.ToInt32(
                    dgvTagihan.Rows[e.RowIndex].Cells["lease_id"].Value
                );
            }
        }
    }
}
