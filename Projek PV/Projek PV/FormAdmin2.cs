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
        }

        private void FormAdmin2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1246, 900);
            panelOverview.Visible = true;
            panelOverview.Location = new Point(230, 2 + 70);
            panelOverview.Size = new Size(932, 650);
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnManage.BringToFront();
            panelBtnFill.BringToFront();
            panelBtnOverview.BringToFront();
            panelBtnNotification.BringToFront();
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
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2 + 70 + 70);
            panelManage.Size = new Size(932, 650);
        }
        private void labelManageRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.Navy;
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2 + 70);
            panelManage.Size = new Size(932, 650);
        }
        private void pictureBoxManageRooms_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.Navy;
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2 + 70);
            panelManage.Size = new Size(932, 650);
        }

        private void panelFillRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.Navy;
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2 + 70);
            panelFill.Size = new Size(932, 650 + 400);
        }
        private void labelFillRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.Navy;
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2 + 70);
            panelFill.Size = new Size(932, 650);
        }
        private void pictureBoxFillRoom_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.Navy;
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2 + 70);
            panelFill.Size = new Size(932, 650);
        }
        private void panelOverView_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2 + 70);
            panelOverview.Size = new Size(932, 650);
        }
        private void labelOverview_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2 + 70);
            panelOverview.Size = new Size(932, 650);
        }
        private void pictureBoxOverview_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2 + 70);
            panelOverview.Size = new Size(932, 650);
        }
        private void panelLaporan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.Navy;
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelNotification.Location = new Point(230, 2 + 70);
            panelNotification.Size = new Size(932, 650);
        }
        private void labelLaporan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.Navy;
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelNotification.Location = new Point(230, 2 + 70);
            panelNotification.Size = new Size(932, 650);
        }
        private void pictureBoxLaporan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.Navy;
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelNotification.Location = new Point(230, 2 + 70);
            panelNotification.Size = new Size(932, 650);
        }
        private void panelPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2 + 70);
            panelPenghunidanTagihan.Size = new Size(932, 650);
        }
        private void labelPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2 + 70);
            panelPenghunidanTagihan.Size = new Size(932, 650);
        }
        private void pictureBoxPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnMonitoring.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2 + 70);
            panelPenghunidanTagihan.Size = new Size(932, 650);
        }
        private void panelMonitoringTamu_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.Navy;
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = true;
            panelMonitorTamuh.Location = new Point(230, 2 + 70);
            panelMonitorTamuh.Size = new Size(932, 650);
        }
        private void labelMonitoringTamu_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.Navy;
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = true;
            panelMonitorTamuh.Location = new Point(230, 2 + 70);
            panelMonitorTamuh.Size = new Size(932, 650);
        }
        private void pictureBoxMonitoringTamu_Click(object sender, EventArgs e)
        {
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnNotification.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnMonitoring.BackColor = Color.Navy;
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelNotification.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = true;
            panelMonitorTamuh.Location = new Point(230, 2 + 70);
            panelMonitorTamuh.Size = new Size(932, 650);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbOccupant2_CheckedChanged(object sender, EventArgs e)
        {
            if(cbOccupant2.Checked)
            {
                gbOccupant2.Enabled = true;
            }
            else
            {
                gbOccupant2.Enabled = false;
            }
        }
    }
}
