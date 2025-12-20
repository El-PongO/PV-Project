using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projek_PV
{
    public partial class Form1 : Form
    {

        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            //INI DERILL DATABASE USAGE
            if(tbUsername.Text =="" || tbPassword.Text =="")
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM users WHERE username = @user AND password = @pass";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@user", tbUsername.Text);
                        cmd.Parameters.AddWithValue("@pass", tbPassword.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {


                            if (reader.HasRows)
                            {
                                reader.Read();
                                int id = Convert.ToInt32(reader["user_id"]);
                                string role = reader["role"].ToString();

                                tbUsername.Text = "";
                                tbPassword.Text = "";

                                if (role == "admin")
                                {
                                    FormAdmin2 formadmin = new FormAdmin2();
                                    formadmin.Show();

                                }
                                else
                                {
                                    FormUser2 formm = new FormUser2(id, this);
                                    formm.Show();

                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("User not Found! Please check your username or password");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }



        }
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
