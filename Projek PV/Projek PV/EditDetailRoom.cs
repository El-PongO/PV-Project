using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projek_PV
{
    public partial class EditDetailRoom : Form
    {
        private string selectedStatus = "";
        private string roomNumber;
        private string connectionString;

        public EditDetailRoom()
        {
            InitializeComponent();
        }

        public EditDetailRoom(string roomNumber, string connStr)
        {
            InitializeComponent();
            this.roomNumber = roomNumber;
            this.connectionString = connStr;

            txtRoomNumber.Text = roomNumber;
            txtRoomNumber.ReadOnly = true;

            LoadRoomDetail();
        }

        private void LoadRoomDetail()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT type, base_price, status
                    FROM rooms
                    WHERE room_number = @room";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room", roomNumber);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtType.Text = reader["type"].ToString();
                            numPrice.Value = Convert.ToDecimal(reader["base_price"]);
                            selectedStatus = reader["status"].ToString();
                        }
                    }
                }
            }
        }

        private void btnTerisi_Click(object sender, EventArgs e)
        {
            selectedStatus = "Terisi";
        }

        private void btnTersedia_Click(object sender, EventArgs e)
        {
            selectedStatus = "Tersedia";
        }

        private void btnPerbaikan_Click(object sender, EventArgs e)
        {
            selectedStatus = "Perbaikan";
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedStatus))
            {
                MessageBox.Show("Please select room status.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    UPDATE rooms
                    SET 
                        type = @type,
                        base_price = @price,
                        status = @status
                    WHERE room_number = @room";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", txtType.Text);
                    cmd.Parameters.AddWithValue("@price", numPrice.Value);
                    cmd.Parameters.AddWithValue("@status", selectedStatus);
                    cmd.Parameters.AddWithValue("@room", roomNumber);

                    cmd.ExecuteNonQuery();
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
