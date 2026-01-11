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
        public static int LoggedInUserId { get; private set; }

        //string connectionString = "Server=172.20.10.5;Database=cozy_corner_db;Uid=root;Pwd=;";
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

            if(tbUsername.Text == "admin" && tbPassword.Text == "123")
            {
                FormAdmin2 formadmin = new FormAdmin2();
                formadmin.Show();
                this.Hide();
                return;
            }


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                try
                {
                    connection.Open();

                    string query = @"
                    SELECT u.user_id, u.username, u.password, l.status, u.role, l.start_date, r.room_number, l.payment_type, T.tenant_id
                    FROM users u 
                    JOIN tenants t ON t.user_id = u.user_id 
                    JOIN leases l ON t.tenant_id = l.tenant_id 
                    join rooms r ON l.room_id = r.room_id
                    WHERE u.username = @user AND u.password = @pass";
                    

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
                                string status = reader["status"].ToString();
                                DateTime tanggal = Convert.ToDateTime(reader["start_date"]);
                                string kamar = reader["room_number"].ToString();
                                string tipe = reader["payment_type"].ToString();
                                int tenant_id = Convert.ToInt32(reader["tenant_id"]); 


                                LoggedInUserId = id;

                                tbUsername.Text = "";
                                tbPassword.Text = "";

                                if(status == "Active")
                                {

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

                                }else if(status == "Booked")
                                {
                                    form_booked form_Booked = new form_booked(tanggal,kamar, tipe, tenant_id);
                                    form_Booked.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Your account is inactive. Please contact the administrator.");
                                }
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
