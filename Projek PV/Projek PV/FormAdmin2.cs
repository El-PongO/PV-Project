using MySql.Data.MySqlClient;
using System;
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
    public partial class FormAdmin2 : Form
    {
        public static int colscounter = 0;
        public static int rowscounter = 0;
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        public FormAdmin2()
        {
            InitializeComponent();
            flowLayoutPanelKamar.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelKamar.WrapContents = true;
            flowLayoutPanelKamar.AutoScroll = true;
            flowLayoutPanelLaporan.AutoScroll = true;
            panelFill.AutoScroll = true;
            flowLayoutPanelExtensions.AutoScroll = true;
        }

        private void FormAdmin2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1246, 900);

            panelOverview.Visible = true;
            panelManage.Visible = false;
            flowLayoutPanelLaporan.Visible = false;
            panelFill.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelExtensions.Visible = false;
            panelListrik.Visible = true;

            panelOverview.Location = new Point(230, 82);
            panelOverview.Size = new Size(1000, 600);
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtensions.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnManage.BringToFront();
            panelBtnFill.BringToFront();
            panelBtnOverview.BringToFront();
            panelBtnLaporan.BringToFront();
            panelBtnPenghuni.BringToFront();
            panelBtnExtensions.BringToFront();
            panelBtnListrik.BringToFront();

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
            panelBtnExtensions.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            // panel isinya
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelExtensions.Visible = false;
            panelListrik.Visible = false;

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
            panelBtnExtensions.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            // isinya panel
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            flowLayoutPanelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelExtensions.Visible = false;
            panelListrik.Visible = false;
            // nge set
            panelFill.Location = new Point(230, 82);
            panelFill.Size = new Size(1000, 600);
            lblHeader.Text = "Fill Room";
        }
        private void NavBar_Overview_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtensions.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            // ini ngeset isinya panel
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            flowLayoutPanelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelExtensions.Visible = false;
            panelListrik.Visible = false;
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
            panelBtnExtensions.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            // ini isinya panel 
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelLaporan.Visible = true;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelExtensions.Visible = false;
            panelListrik.Visible = false;
            // nge set
            flowLayoutPanelLaporan.Location = new Point(230, 82);
            flowLayoutPanelLaporan.Size = new Size(1000, 600);
            lblHeader.Text = "Laporan";
            //CreateComplaintCard();


            //CreateComplaintCard(string category, string nama, string kamar, string date, string msg)

            //clear dulu biar ga ke doble2
            flowLayoutPanelLaporan.Controls.Clear();

            string sql = "SELECT * from complaints c join tenants t on t.tenant_id = c.tenant_id join leases l on l.tenant_id = t.tenant_id join rooms r on r.room_id = l.room_id WHERE c.status = 'Menunggu'";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CreateComplaintCard(Convert.ToInt32(reader["complaint_id"]),reader["category"].ToString(), reader["full_name"].ToString(), reader["room_number"].ToString(), reader["created_at"].ToString(), reader["description"].ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
            }
           
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
            panelBtnExtensions.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            // ini isinya panel nanti
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelLaporan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            flowLayoutPanelExtensions.Visible = false;
            panelListrik.Visible = false;
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
            panelBtnExtensions.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.Navy;
            // ini buat tampilin isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = true;
            flowLayoutPanelExtensions.Visible = false;
            panelListrik.Visible = false;
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
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtensions.BackColor = Color.Navy;
            // ini buat tampilin isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelExtensions.Visible = true;
            panelListrik.Visible = false;
            // nge set
            flowLayoutPanelExtensions.Location = new Point(230, 72);
            flowLayoutPanelExtensions.Size = new Size(1000, 600);
            lblHeader.Text = "Extensions";
            
        }
        private void NavBar_Listrik_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnExtensions.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.Navy;
            // ini buat tampilin isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            flowLayoutPanelExtensions.Visible = false;
            panelListrik.Visible = true;
            // nge set
            panelListrik.Location = new Point(230, 72);
            panelListrik.Size = new Size(1000, 600);
            lblHeader.Text = "Listrik";
            
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
            lblPrice.Text = "Rp " + Convert.ToInt32(row["Price"]).ToString("N0");
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

            card.Controls.Add(btnEdit);

            // Finally add card to the FlowLayoutPanel
            flowLayoutPanelKamar.Controls.Add(card);
        }
        private DataTable GetRoomData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("RoomName");
            dt.Columns.Add("RoomType");
            dt.Columns.Add("Price");
            dt.Columns.Add("Status");
            dt.Columns.Add("Facilities");

            // Sample sets to vary room data
            string[] types = { "Standard AC", "Standard Non-AC", "VIP AC" };
            string[] facilitiesOptions = {
                "AC,WiFi,Kasur,Lemari",
                "WiFi,Kasur,Lemari",
                "AC,WiFi,Kasur,Lemari,Kulkas,TV",
                "AC,WiFi,Kasur,Lemari,Meja Belajar"
            };

            // Create 40 sample rooms (Kamar 101..Kamar 140)
            for (int i = 1; i <= 40; i++)
            {
                int roomNumber = 100 + i;
                string roomName = $"Kamar {roomNumber}";
                string roomType = types[i % types.Length];
                string facilities = facilitiesOptions[i % facilitiesOptions.Length];
                string price = roomType.Contains("VIP") ? "2200000" : "1500000";
                string status = (i % 4 == 0) ? "Tersedia" : "Terisi"; // every 4th room available

                dt.Rows.Add(roomName, roomType, price, status, facilities);
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

        private void CreateComplaintCard(int id,string category, string nama, string kamar, string date, string msg)
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
            lblSub.Text = nama + " · Kamar " + kamar + " · " + date;
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
            cmbStatus.Items.AddRange(new string[] { "Menunggu", "Diproses", "Selesai" });
            cmbStatus.SelectedIndex = 0;
            cmbStatus.BackColor = statusPanel.FillColor;
            cmbStatus.ForeColor = Color.DarkRed;

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
            lblMsg.Text = msg;
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


                using(MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateSql = "UPDATE complaints SET status = @status, admin_reply = @response, reply_at = @time WHERE complaint_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                        cmd.Parameters.AddWithValue("@response", txtReply.Text);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@time", DateTime.Now);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Balasan terkirim dan status diperbarui.");
                            flowLayoutPanelLaporan.Controls.Remove(card);
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengirim balasan. Silakan coba lagi.");
                        }
                    }
                }
            };


         
            card.Controls.Add(btnSend);

            flowLayoutPanelLaporan.Controls.Add(card);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
