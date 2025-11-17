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
    public partial class formAdmin : Form
    {
        private int menuExpandedWidth = 205;
        private int menuCollapsedWidth = 61;
        public formAdmin()
        {
            InitializeComponent();
            CollapseMenu();
            panelHamburgExpand.Visible = false;
            panelHamburg.Visible = true;

            //ol the panels
            panelManageRoom.Visible = false;
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelUserRole.Visible = false;
            //MessageBox.Show("bababababanna");

            //panelHamburg.Width = menuCollapsedWidth;

            //panelContent.Left = panelHamburg.Width;
            //panelContent.Width = this.Width - panelHamburg.Width;
        }

        private void formAdmin_Load(object sender, EventArgs e)
        {

        }

        private void CollapseMenu()
        {
            // Tampilkan menu kecil
            panelHamburg.Visible = true;
            panelHamburg.Width = menuCollapsedWidth;

            // Sembunyikan menu besar
            panelHamburgExpand.Visible = false;

            // Geser area content sesuai lebar menu kecil
            panelContent.Left = panelHamburg.Width;
            panelContent.Width = this.Width - panelContent.Left;

            labelWelcomeAdmin.Location = new Point(76, 65);
            labelRoomList.Location = new Point(81, 105);
            dataGridView1.Location = new Point(81, 141);
            panelContent.Location = new Point(338, 141);
        }


        private void ExpandMenu()
        {
            // Tampilkan menu besar
            panelHamburgExpand.Visible = true;
            panelHamburgExpand.Width = menuExpandedWidth;

            // Sembunyikan menu kecil
            panelHamburg.Visible = false;

            // Geser area content sesuai lebar menu besar
            panelContent.Left = panelHamburgExpand.Width;
            panelContent.Width = this.Width - panelContent.Left;

            labelWelcomeAdmin.Location = new Point(238, 65);
            labelRoomList.Location = new Point(243, 105);
            dataGridView1.Location = new Point(243, 141);
            panelContent.Location = new Point(500, 141);
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //panelHamburg.Visible = false;
            //panelHamburgCollapse.Visible = true;
            //CollapseMenu();
            //MessageBox.Show("haloh ini teken mau expand");
            ExpandMenu();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //panelHamburgCollapse.Visible = false;
            //panelHamburg.Visible = true;
            //MessageBox.Show("kalo ini mau collapse");
            CollapseMenu();
            //ExpandMenu();
        }

        //ini kalo manage room diteken
        private void label3_Click_1(object sender, EventArgs e)
        {
            panelManageRoom.Visible = true;
            panelAdmin.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelManageRoom.Visible = true;
            panelAdmin.Visible = false;
        }

        private void panel7_Paint_1(object sender, PaintEventArgs e)
        {
            panelManageRoom.Visible = true;
            panelAdmin.Visible = false;
        }

        //ini yang kalo admin e diteken 
        private void label4_Click(object sender, EventArgs e)
        {
            panelAdmin.Visible = true;
            panelManageRoom.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelAdmin.Visible = true;
            panelManageRoom.Visible = false;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            panelAdmin.Visible = true;
            panelManageRoom.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = true;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            panelAccounting.Visible = true;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = true;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void pictureBoxHamburgMenu_Click(object sender, EventArgs e)
        {
            ExpandMenu();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = true;
            panelUserRole.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = true;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = true;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxHamburg_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        //manage room
        private void labelManageRoom_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = true;
            panelUserRole.Visible = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = true;
            panelUserRole.Visible = false;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = true;
            panelUserRole.Visible = false;
        }

        //ini admin
        private void labelAdmin_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = true;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = true;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void panel8_Paint_1(object sender, PaintEventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = true;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }


        //ini kalo accounting
        private void labelAccounting_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = true;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            panelAccounting.Visible = true;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        private void panel9_Paint_1(object sender, PaintEventArgs e)
        {
            panelAccounting.Visible = true;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = false;
        }

        //ini kalo user
        private void labelUser_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = true;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            panelAccounting.Visible = false;
            panelAdmin.Visible = false;
            panelManageRoom.Visible = false;
            panelUserRole.Visible = true;
        }
    }
}
