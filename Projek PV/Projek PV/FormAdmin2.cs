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

        private void panelManageRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.Navy;
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2+50);
            panelManage.Size = new Size(1000, 600);
        }
        private void labelManageRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.Navy;
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2);
            panelManage.Size = new Size(1000, 600);
        }
        private void pictureBoxManageRooms_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.Navy;
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2);
            panelManage.Size = new Size(1000, 600);
        }

        private void panelFillRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.Navy;
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2);
            panelFill.Size = new Size(1000, 600);
        }
        private void labelFillRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.Navy;
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2);
            panelFill.Size = new Size(1000, 600);
        }
        private void pictureBoxFillRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.Navy;
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2);
            panelFill.Size = new Size(1000, 600);
        }
        private void panelOverView_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2);
            panelOverview.Size = new Size(1000, 600);
        }
        private void labelOverview_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2);
            panelOverview.Size = new Size(1000, 600);
        }
        private void pictureBoxOverview_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2);
            panelOverview.Size = new Size(1000, 600);
        }
        private void panelLaporan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.Navy;
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelLaporan.Location = new Point(230, 2);
            panelLaporan.Size = new Size(1000, 600);
        }
        private void labelLaporan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.Navy;
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelLaporan.Location = new Point(230, 2);
            panelLaporan.Size = new Size(1000, 600);
        }
        private void pictureBoxLaporan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.Navy;
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelLaporan.Location = new Point(230, 2);
            panelLaporan.Size = new Size(1000, 600);
        }
        private void panelPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2);
            panelPenghunidanTagihan.Size = new Size(1000, 600);
        }
        private void labelPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2);
            panelPenghunidanTagihan.Size = new Size(1000, 600);
        }
        private void pictureBoxPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2);
            panelPenghunidanTagihan.Size = new Size(1000, 600);
        }
        private void pictureBoxPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2);
            panelPenghunidanTagihan.Size = new Size(1000, 600);
        }
        private void NavBar_MonitoringTamu_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.Navy;
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = true;
            panelMonitorTamuh.Location = new Point(230, 2);
            panelMonitorTamuh.Size = new Size(1000, 600);
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
            flowLayoutPanelKamar.BackColor = Color.Navy;
            // ini buat tampilin isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = false;
            flowLayoutPanelKamar.Visible = true;
            // nge set
            panelMonitorTamuh.Location = new Point(230, 2);
            panelMonitorTamuh.Size = new Size(1000, 600);
            LoadRoomCards();
        }
        private void CreateRoomCard(DataRow row)
        {
            // MAIN CARD PANEL
            Panel card = new Panel();
            card.Width = 350;
            card.Height = 220;
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

            dt.Rows.Add("Kamar 101", "Standard AC", "1500000", "Terisi", "AC,WiFi,Kasur,Lemari");
            dt.Rows.Add("Kamar 102", "Standard AC", "1500000", "Tersedia", "AC,WiFi,Kasur,Lemari");
            dt.Rows.Add("Kamar 103", "VIP AC", "2200000", "Tersedia", "AC,WiFi,Kasur,Lemari,Kulkas,TV");
            dt.Rows.Add("Kamar 104", "Standard AC", "1500000", "Terisi", "AC,WiFi,Kasur");

            return dt;
        }

        private void LoadRoomCards()
        {
            DataTable dt = GetRoomData(); // your dummy DB

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
