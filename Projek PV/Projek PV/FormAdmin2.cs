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
            panel3.BackColor = Color.FromArgb(137, 200, 241);
            panel2.BackColor = Color.FromArgb(137, 200, 241);
            panel2.BringToFront();
            panel3.BringToFront();

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

        private void panel2_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(9, 119, 255);
            panel3.BackColor = Color.FromArgb(137, 200, 241);
            panelManage.Visible = true;
            panelFill.Visible = false;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(9, 119, 255);
            panel2.BackColor = Color.FromArgb(137, 200, 241);
            panelManage.Visible = false;
            panelFill.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
