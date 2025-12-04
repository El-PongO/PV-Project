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
            this.Size = new Size(1139, 850);
            panelOverview.Visible = true;
            panelOverview.Location = new Point(230, 2);
            panelOverview.Size = new Size(1139, 919);
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.Navy;
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panel2.BringToFront();
            panel3.BringToFront();
            panel4.BringToFront();
            panel6.BringToFront();
            panel7.BringToFront();
            panel13.BringToFront();


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

            dataGridView1.DataSource = roomTable;

            dataGridView1.Columns["RoomCode"].HeaderText = "Kode Ruangan";
            dataGridView1.Columns["Occupied"].HeaderText = "Terisi";
            dataGridView1.Columns["TenantName"].HeaderText = "Nama Penyewa";
            dataGridView1.Columns["RentDue"].HeaderText = "Jatuh Tempo Sewa";
            dataGridView1.Columns["Occupied"].Width = 60;

            panelFill.Location = new Point(238, -1);
            panelFill.Visible = false;
        }

        private void panelManageRoom_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Navy;
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2);
            panelManage.Size = new Size(1139, 919);
        }
        private void labelManageRoom_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Navy;
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2);
            panelManage.Size = new Size(1139, 919);
        }
        private void pictureBoxManageRooms_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Navy;
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelManage.Location = new Point(230, 2);
            panelManage.Size = new Size(1139, 919);
        }

        private void panelFillRoom_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.Navy;
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2);
            panelFill.Size = new Size(1139, 919);
        }
        private void labelFillRoom_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.Navy;
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2);
            panelFill.Size = new Size(1139, 919);
        }
        private void pictureBoxFillRoom_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.Navy;
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelFill.Location = new Point(230, 2);
            panelFill.Size = new Size(1139, 919);
        }
        private void panelOverView_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.Navy;
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2);
            panelOverview.Size = new Size(1139, 919);
        }
        private void labelOverview_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.Navy;
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2);
            panelOverview.Size = new Size(1139, 919);
        }
        private void pictureBoxOverview_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.Navy;
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelOverview.Location = new Point(230, 2);
            panelOverview.Size = new Size(1139, 919);
        }
        private void panelLaporan_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.Navy;
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelLaporan.Location = new Point(230, 2);
            panelLaporan.Size = new Size(1139, 919);
        }
        private void labelLaporan_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.Navy;
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelLaporan.Location = new Point(230, 2);
            panelLaporan.Size = new Size(1139, 919);
        }
        private void pictureBoxLaporan_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.Navy;
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = true;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelLaporan.Location = new Point(230, 2);
            panelLaporan.Size = new Size(1139, 919);
        }
        private void panelPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.Navy;
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2);
            panelPenghunidanTagihan.Size = new Size(1139, 919);
        }
        private void labelPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.Navy;
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2);
            panelPenghunidanTagihan.Size = new Size(1139, 919);
        }
        private void pictureBoxPenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.Navy;
            panel13.BackColor = Color.FromArgb(0, 0, 64);
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelMonitorTamuh.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            panelPenghunidanTagihan.Location = new Point(230, 2);
            panelPenghunidanTagihan.Size = new Size(1139, 919);
        }
        private void panelMonitoringTamu_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.Navy;
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = true;
            panelMonitorTamuh.Location = new Point(230, 2);
            panelMonitorTamuh.Size = new Size(1139, 919);
        }
        private void labelMonitoringTamu_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.Navy;
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = true;
            panelMonitorTamuh.Location = new Point(230, 2);
            panelMonitorTamuh.Size = new Size(1139, 919);
        }
        private void pictureBoxMonitoringTamu_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel6.BackColor = Color.FromArgb(0, 0, 64);
            panel7.BackColor = Color.FromArgb(0, 0, 64);
            panel13.BackColor = Color.Navy;
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            panelLaporan.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelMonitorTamuh.Visible = true;
            panelMonitorTamuh.Location = new Point(230, 2);
            panelMonitorTamuh.Size = new Size(1139, 919);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
