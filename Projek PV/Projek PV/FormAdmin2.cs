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
    public partial class FormAdmin2 : Form
    {
        public static int colscounter = 0;
        public static int rowscounter = 0;
        public FormAdmin2()
        {
            InitializeComponent();
            flowLayoutPanelKamar.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelKamar.WrapContents = true;
            flowLayoutPanelKamar.AutoScroll = true;
        }

        private void FormAdmin2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1246, 900);
            panelOverview.Visible = true;
            panelOverview.Location = new Point(230, 2);
            panelOverview.Size = new Size(1000, 600);
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnManage.BringToFront();
            panelBtnFill.BringToFront();
            panelBtnOverview.BringToFront();
            panelBtnLaporan.BringToFront();
            panelBtnPenghuni.BringToFront();
            panelBtnMonitoring.BringToFront();


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
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            // panel isinya
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
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
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            // isinya panel
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
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
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            // ini ngeset isinya panel
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
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
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            // ini isinya panel 
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            // nge set
            panelLaporan.Location = new Point(230, 82);
            panelLaporan.Size = new Size(1000, 600);
            lblHeader.Text = "Laporan";
        }
        private void NavBar_PenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            // ini isinya panel nanti
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            // nge set
            panelPenghunidanTagihan.Location = new Point(230, 82);
            panelPenghunidanTagihan.Size = new Size(1000, 600);
            lblHeader.Text = "Penghuni dan Tagihan";
        }
        private void NavBar_MonitoringTamu_Click(object sender, EventArgs e)
        {
            //panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.Navy;
            // nge set isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            flowLayoutPanelKamar.Visible = false;
            panelMonitorTamuh.Visible = true;
            // nge set
            panelMonitorTamuh.Location = new Point(230, 82);
            panelMonitorTamuh.Size = new Size(1000, 600);
            lblHeader.Text = "Monitoring Tamu";
        }
        private void NavBar_Kamar_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.Navy;
            // ini buat tampilin isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = false;
            flowLayoutPanelKamar.Visible = true;
            // nge set
            flowLayoutPanelKamar.Location = new Point(230, 72);
            flowLayoutPanelKamar.Size = new Size(1000, 600);
            lblHeader.Text = "Kamar";
            LoadRoomCards();
        }
        private void CreateRoomCard(DataRow row)
        {
            // MAIN CARD PANEL
            Panel card = new Panel();
            card.Width = 307;
            card.Height = 210;
            card.BackColor = Color.White;
            card.Margin = new Padding(10);
            card.BorderStyle = BorderStyle.FixedSingle;

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
                Label chip = new Label();
                chip.Text = f.Trim();
                chip.BackColor = Color.Gainsboro;
                chip.Padding = new Padding(6, 3, 6, 3);
                chip.Margin = new Padding(3);
                chip.AutoSize = true;

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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
