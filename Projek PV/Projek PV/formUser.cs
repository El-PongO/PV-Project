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
    public partial class formUser : Form
    {
        public formUser()
        {
            InitializeComponent();
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            lblUsername.Text = "User";

            var table = new DataTable();
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Notification", typeof(string));

            table.Rows.Add(DateTime.Now.AddMinutes(-30).ToString("HH:mm") + Environment.NewLine + "From Admin", "Water supply maintenance scheduled at 3 PM.");
            table.Rows.Add(DateTime.Now.ToString("HH:mm") + Environment.NewLine + "System", "New announcement: Rent due next week.");

            dataGridView1.DataSource = table;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbTitle.Clear();
            tbDesc.Clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your report has been submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbTitle.Clear();
            tbDesc.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }
    }
}
