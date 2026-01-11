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
    public partial class isiData : Form
    {

        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";
        private int roomId;
        private string roomNumber;
        private decimal roomPrice;
        private DateTime startDate;
        private int duration;
        public isiData(int roomId, string roomNumber, decimal roomPrice, DateTime startDate, int duration)
        {
            InitializeComponent();
            panelFill.AutoScroll = true;

            this.roomId = roomId;
            this.roomNumber = roomNumber;
            this.roomPrice = roomPrice;
            this.startDate = startDate;
            this.duration = duration;

            comboDurationFill.Value = duration;
            comboDurationFill.Enabled = false;

            comboRoomFill.Text = roomNumber.ToString();
            comboRoomFill.SelectedValue = roomId;
            comboRoomFill.Enabled = false;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            gbOccupant2Fill.Enabled = false;

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                gbOccupant2Fill.Enabled = true;
            }
            else
            {
                gbOccupant2Fill.Enabled = false;
            }

        }

        private void comboRoomFill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbConfirmData_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmitFill_Click(object sender, EventArgs e)
        {
            // Validasi Input Penghuni
            if (string.IsNullOrWhiteSpace(tbNama1.Text))
            {
                MessageBox.Show("Isi Nama Penyewa Terlebih Dahulu");
                return;
            }

            if(cbConfirmData.Checked == false)
            {
                MessageBox.Show("Konfirmasi Data Terlebih Dahulu");
                return;
            }   

            // Jika roomId kosong (berarti form dibuka tanpa lewat pencarian), validasi comboRoomFill
            if (this.roomId == 0 && comboRoomFill.SelectedValue == null)
            {
                MessageBox.Show("Pilih kamar terlebih dahulu");
                return;
            }

            // Fallback: Jika roomId 0, ambil dari combobox
            int finalRoomId = this.roomId != 0 ? this.roomId : Convert.ToInt32(comboRoomFill.SelectedValue);
            int finalDuration = this.duration != 0 ? this.duration : (int)comboDurationFill.Value;

            // Jika lewat form pencarian, pakai startDate. Jika manual, pakai Hari Ini.
            DateTime finalStartDate = this.roomId != 0 ? this.startDate : DateTime.Today;

            // --- LOGIKA STATUS SEWA ---
            // Jika Tanggal Masuk > Hari Ini = Booked
            // Jika Tanggal Masuk <= Hari Ini = Active (Langsung Masuk)
            string leaseStatus = (finalStartDate.Date > DateTime.Now.Date) ? "Booked" : "Active";

            string gender = radioWanita1.Checked ? "Perempuan" : "Laki-Laki";
            int tenantCount = checkBox4.Checked ? 2 : 1;
            string paymentType = radioSemuaBulan.Checked ? "IMMEDIATE" : "CONSECUTIVE";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction tr = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. GET BASE PRICE (Jika belum ada dari constructor)
                        decimal basePrice = this.roomPrice;
                        if (basePrice == 0)
                        {
                            using (MySqlCommand cmd = new MySqlCommand("SELECT base_price FROM rooms WHERE room_id = @id", conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@id", finalRoomId);
                                basePrice = Convert.ToDecimal(cmd.ExecuteScalar());
                            }
                        }

                        // 2. APPLY CHARGE (30% if 2 people)
                        decimal monthlyPrice = basePrice;
                        if (checkBox4.Checked) monthlyPrice += monthlyPrice * 0.3m;

                        // 3. INSERT USER (Akun Login)
                        long userId;
                        using (MySqlCommand c1 = new MySqlCommand("INSERT INTO users(username,password, role) VALUES(@u,'123', 'tenant')", conn, tr))
                        {
                            c1.Parameters.AddWithValue("@u", tbNama1.Text);
                            c1.ExecuteNonQuery();
                            userId = c1.LastInsertedId;
                        }

                        // 4. INSERT TENANT (Data Diri)
                        long tenantId;
                        string qTenant = @"INSERT INTO tenants (user_id, full_name, ktp_number, gender, date_of_birth, address) VALUES (@u,@n,@k,@g,@d,@a)";
                        using (MySqlCommand c2 = new MySqlCommand(qTenant, conn, tr))
                        {
                            c2.Parameters.AddWithValue("@u", userId);
                            c2.Parameters.AddWithValue("@n", tbNama1.Text);
                            c2.Parameters.AddWithValue("@k", tbNIK1.Text);
                            c2.Parameters.AddWithValue("@g", gender);
                            c2.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                            c2.Parameters.AddWithValue("@a", tbAlamat1.Text);
                            c2.ExecuteNonQuery();
                            tenantId = c2.LastInsertedId;
                        }

                        // 5. INSERT SECOND TENANT (Jika ada)
                        if (checkBox4.Checked)
                        {
                            using (MySqlCommand c2b = new MySqlCommand(qTenant, conn, tr))
                            {
                                // Tenant kedua tidak punya User ID (NULL)
                                c2b.Parameters.AddWithValue("@u", DBNull.Value);
                                c2b.Parameters.AddWithValue("@n", tbNama2.Text);
                                c2b.Parameters.AddWithValue("@k", tbNIK2.Text);
                                c2b.Parameters.AddWithValue("@g", radioWanita2.Checked ? "Perempuan" : "Laki-Laki");
                                c2b.Parameters.AddWithValue("@d", dateTimePicker2.Value);
                                c2b.Parameters.AddWithValue("@a", tbAlamat2.Text);
                                c2b.ExecuteNonQuery();
                            }
                        }

                        // 6. INSERT LEASE (Sewa)
                        DateTime endDate = finalStartDate.AddMonths(finalDuration);

                        // Hitung Rent Due (Jatuh Tempo Berikutnya)
                        object rentDueVal = DBNull.Value;
                        if (paymentType == "CONSECUTIVE")
                        {
                            // Jatuh tempo berikutnya adalah 1 bulan setelah tanggal mulai
                            rentDueVal = finalStartDate.AddMonths(1);
                        }

                        string qLease = @"INSERT INTO leases 
                                        (room_id, tenant_id, tenant_count, rent_price, start_date, end_date, duration_months, rent_due, payment_type, status)
                                        VALUES (@r,@t,@c,@p,@s,@e,@d,@due,@ptype, @status)";

                        long leaseId;
                        using (MySqlCommand c3 = new MySqlCommand(qLease, conn, tr))
                        {
                            c3.Parameters.AddWithValue("@r", finalRoomId);
                            c3.Parameters.AddWithValue("@t", tenantId);
                            c3.Parameters.AddWithValue("@c", tenantCount);
                            c3.Parameters.AddWithValue("@p", monthlyPrice);
                            c3.Parameters.AddWithValue("@s", finalStartDate); // PENTING: Pakai tanggal yang dipilih
                            c3.Parameters.AddWithValue("@e", endDate);
                            c3.Parameters.AddWithValue("@d", finalDuration);
                            c3.Parameters.AddWithValue("@due", rentDueVal);
                            c3.Parameters.AddWithValue("@ptype", paymentType);
                            c3.Parameters.AddWithValue("@status", leaseStatus); // 'Active' atau 'Booked'
                            c3.ExecuteNonQuery();
                            leaseId = c3.LastInsertedId;
                        }

                        // 7. INSERT TRANSACTION (Pembayaran Pertama / DP)
                        decimal paymentAmount;
                        string desc;

                        if (paymentType == "IMMEDIATE")
                        {
                            paymentAmount = monthlyPrice * finalDuration;
                            desc = $"Pembayaran Lunas {finalDuration} Bulan (Mulai: {finalStartDate:dd-MM-yyyy})";
                        }
                        else
                        {
                            paymentAmount = monthlyPrice;
                            desc = leaseStatus == "Booked"
                                ? $"Booking Fee / Pembayaran Bulan Pertama (Check-in: {finalStartDate:dd-MM-yyyy})"
                                : $"Pembayaran Sewa Bulan ke-1 (Mulai: {finalStartDate:dd-MM-yyyy})";
                        }

                        using (MySqlCommand c4 = new MySqlCommand(@"INSERT INTO transactions (lease_id, description, amount, status, category, transaction_date) VALUES (@l, @desc, @amt, 'Paid', 'rent', NOW())", conn, tr))
                        {
                            c4.Parameters.AddWithValue("@l", leaseId);
                            c4.Parameters.AddWithValue("@desc", desc);
                            c4.Parameters.AddWithValue("@amt", paymentAmount);
                            c4.ExecuteNonQuery();
                        }

                        // 8. UPDATE ROOM STATUS
                        // Hanya ubah jadi 'Terisi' jika status sewa 'Active' (Masuk Hari Ini)
                        if (leaseStatus == "Active")
                        {
                            using (MySqlCommand c5 = new MySqlCommand("UPDATE rooms SET status='Terisi' WHERE room_id=@r", conn, tr))
                            {
                                c5.Parameters.AddWithValue("@r", finalRoomId);
                                c5.ExecuteNonQuery();
                            }
                        }

                        tr.Commit();
                        MessageBox.Show(leaseStatus == "Booked"
                            ? "Booking Berhasil Disimpan!"
                            : "Check-In Berhasil!");

                        this.Close(); // Tutup form setelah selesai
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show("Transaksi Gagal: " + ex.Message);
                    }
                }
            }
        }

    }
}
