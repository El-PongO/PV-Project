using MySql.Data.MySqlClient;
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
    public partial class formCreateKamar : Form
    {
        private string connectionString;
        private string selectedStatus = "Tersedia";
        private Button activeStatusButton = null;

        public formCreateKamar(string connStr)
        {
            InitializeComponent();
            connectionString = connStr;

            LoadRoomTypes();
        }

        public void LoadRoomTypes()
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.Add("Standard Non-AC");
            comboBoxType.Items.Add("Standard AC");
            comboBoxType.Items.Add("VIP AC");

            comboBoxType.SelectedIndex = 0;
        }
        private void SetActiveStatusButton(Button btn, string status)
        {
            // reset button lama
            if (activeStatusButton != null)
            {
                activeStatusButton.BackColor = SystemColors.Control;
                activeStatusButton.ForeColor = SystemColors.ControlDarkDark;
            }

            // set button baru
            activeStatusButton = btn;
            selectedStatus = status;

            btn.BackColor = SystemColors.HotTrack;
            btn.ForeColor = SystemColors.Control;
        }

        private void buttonCancel_MouseHover(object sender, EventArgs e)
        {
            buttonCancel.BackColor = Color.FromArgb(220, 80, 80);
            buttonCancel.ForeColor = Color.White;
        }

        private void buttonCancel_MouseLeave(object sender, EventArgs e)
        {
            buttonCancel.BackColor = SystemColors.Control;
            buttonCancel.ForeColor = SystemColors.ControlDarkDark;
        }
        private void buttonStatus_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            btn.BackColor = SystemColors.HotTrack;
            btn.ForeColor = SystemColors.Control;
        }

        private void buttonStatus_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            // ❗ JANGAN reset warna jika ini button yang aktif
            if (btn == activeStatusButton) return;

            btn.BackColor = SystemColors.Control;
            btn.ForeColor = SystemColors.ControlDarkDark;
        }

        private void buttonSimpanKamar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomorKamar.Text))
            {
                MessageBox.Show("Nomor kamar wajib diisi");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            INSERT INTO rooms (room_number, type, base_price, status)
            VALUES (@number, @type, @price, @status)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@number", textBoxNomorKamar.Text);
                    cmd.Parameters.AddWithValue("@type", comboBoxType.Text);
                    cmd.Parameters.AddWithValue("@price", numericUpDownHarga.Value);
                    cmd.Parameters.AddWithValue("@status", selectedStatus);

                    cmd.ExecuteNonQuery();
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTerisi_Click(object sender, EventArgs e)
        {
            //selectedStatus = "Terisi";
            //buttonTerisi.BackColor = SystemColors.HotTrack;
            //buttonTerisi.ForeColor = SystemColors.Control;
            SetActiveStatusButton(buttonTerisi, "Terisi");
        }

        private void buttonTersedia_Click(object sender, EventArgs e)
        {
            //selectedStatus = "Tersedia";
            //buttonTersedia.BackColor = SystemColors.HotTrack;
            //buttonTersedia.ForeColor = SystemColors.Control;
            SetActiveStatusButton(buttonTersedia, "Tersedia");
        }

        private void buttonPerbaikan_Click(object sender, EventArgs e)
        {

            //selectedStatus = "Perbaikan";
            //buttonPerbaikan.BackColor = SystemColors.HotTrack;
            //buttonPerbaikan.ForeColor = SystemColors.Control;
            SetActiveStatusButton(buttonPerbaikan, "Perbaikan");
        }
    }
}
