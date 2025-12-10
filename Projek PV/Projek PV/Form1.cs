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
                MessageBox.Show("Admin Detected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formAdmin formadmin = new formAdmin();
                formadmin.Show();
            }
            else if (tbUsername.Text == "user" && tbPassword.Text == "user")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               formUser userForm = new formUser();  
                userForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdmin2 formadmin = new FormAdmin2();
            formadmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUser2 formm = new FormUser2();
            formm.Show();
        }
    }
}
