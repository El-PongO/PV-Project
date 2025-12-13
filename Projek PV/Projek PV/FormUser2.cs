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
        public FormUser2()
        {
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
    }
}
