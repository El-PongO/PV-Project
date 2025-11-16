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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(tbUsername.Text == "admin" && tbPassword.Text == "admin")
            {
                MessageBox.Show("Welcome Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            } 
            else if (tbUsername.Text == "user" && tbPassword.Text == "user")
            {
                MessageBox.Show("Welcome User!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formUser formUser = new formUser();
                formUser.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
