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
        private Button activeStatusButton = null;

        public EditDetailRoom()
        {
            InitializeComponent();
        }

        private void EditDetailRoom_Load(object sender, EventArgs e)
        {
            LoadRoomTypes();
        }

        public void LoadRoomTypes()
        {
            comboBoxTipeKamar.Items.Clear();
            comboBoxTipeKamar.Items.Add("standart");
            comboBoxTipeKamar.Items.Add("large");

            comboBoxTipeKamar.SelectedIndex = 0;
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
                            comboBoxTipeKamar.Text = reader["type"].ToString();
                            numPrice.Value = Convert.ToDecimal(reader["base_price"]);

                            string status = reader["status"].ToString();

                            if (status == "Tersedia")
                                SetActiveStatusButton(btnTersedia, "Tersedia");
                            else if (status == "Terisi")
                                SetActiveStatusButton(btnTerisi, "Terisi");
                            else if (status == "Perbaikan")
                                SetActiveStatusButton(btnPerbaikan, "Perbaikan");
                        }
                    }
                }
            }
        }
        private void SetActiveStatusButton(Button btn, string status)
        {
            // reset button lama
            if (activeStatusButton != null)
            {
                activeStatusButton.BackColor = SystemColors.Control;
                activeStatusButton.ForeColor = SystemColors.ControlText;
            }

            // set button baru
            activeStatusButton = btn;
            selectedStatus = status;

            btn.BackColor = SystemColors.HotTrack;
            btn.ForeColor = SystemColors.Control;
        }
        private void btnTerisi_Click(object sender, EventArgs e)
        {
            //selectedStatus = "Terisi";
            //btnTerisi.BackColor = SystemColors.HotTrack;
            //btnTerisi.ForeColor = SystemColors.Control;
            SetActiveStatusButton(btnTerisi, "Terisi");
        }

        private void btnTersedia_Click(object sender, EventArgs e)
        {
            //selectedStatus = "Tersedia";
            //btnTersedia.BackColor = SystemColors.HotTrack;
            //btnTersedia.ForeColor = SystemColors.Control;
            SetActiveStatusButton(btnTersedia, "Tersedia");
        }

        private void btnPerbaikan_Click(object sender, EventArgs e)
        {
            //selectedStatus = "Perbaikan";
            //btnPerbaikan.BackColor = SystemColors.HotTrack;
            //btnPerbaikan.ForeColor = SystemColors.Control;
            SetActiveStatusButton(btnPerbaikan, "Perbaikan");
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
                    cmd.Parameters.AddWithValue("@type", comboBoxTipeKamar.Text);
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
