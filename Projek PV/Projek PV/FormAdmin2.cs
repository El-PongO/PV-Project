using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;


namespace Projek_PV
{
    public partial class FormAdmin2 : Form
    {
        //string connectionString = "Server=172.20.10.5;Database=cozy_corner_db;Uid=root;Pwd=;";
        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";
        private int selectedLeaseId = -1;
        private string selectedUsername = "";
        public static int colscounter = 0;
        public static int rowscounter = 0;
        public int tenant_id = 0;
        public int roomNum = 0;
        public int roomId = 0;


        public FormAdmin2()
        {
            InitializeComponent();
            flowLayoutPanelKamar.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelKamar.WrapContents = true;
            flowLayoutPanelKamar.AutoScroll = true;
            //flowLayoutPanelKamar.Dock = DockStyle.Fill;
            //flowLayoutPanelKamar.Height = 150;
            flowLayoutPanelKamar.AutoSize = false;

            flowLayoutPanelComplaints.AutoScroll = true;
            flowLayoutPanelComplaints.AutoSize = false;

            flowLayoutPanelPendapatan.AutoScroll = true;

            flowLayoutPanelListrik.Visible = true;
            flowLayoutPanelListrik.AutoScroll = true;

            flowLayoutPanelGuestLog.Visible = true;
            flowLayoutPanelGuestLog.AutoSize = false;
            flowLayoutPanelGuestLog.AutoScroll = true;

            panelFill.AutoScroll = true;
            radioWanita1.Checked = true;
            radioWanita2.Checked = true;

            addPengumuman.Visible = false;
        }

        private void FormAdmin2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1246, 900);

            panelOverview.Visible = true;
            panelManage.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelFill.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            panelListrik.Visible = false;
            panelGuestLog.Visible = false;

            panelOverview.Location = new Point(230, 82);
            panelOverview.Size = new Size(1000, 600);
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnManage.BringToFront();
            panelBtnFill.BringToFront();
            panelBtnOverview.BringToFront();
            panelBtnLaporan.BringToFront();
            panelBtnPenghuni.BringToFront();
            panelBtnListrik.BringToFront();
            panelBtnGuestLog.BringToFront();

            panelFill.Location = new Point(238, -1);
            panelFill.Visible = false;
            loadComboBox();
            LoadDgvOverview();
            LoadDgvTagihan();
            updateOverview();
            loadDgvNotif();

        }



        private void NavBar_ManageRooms_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.Navy;
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);

            // panel isinya
            panelManage.Visible = true;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = false;
            panelListrik.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            panelGuestLog.Visible = false;

            if (roundedPanelOccupant1.Visible != true)
            {
                roundedPanelOccupant2.Visible = true;
            }
            else
            {
                roundedPanelOccupant2.Visible = false;
            }
            // ngeset
            panelManage.Location = new Point(230, 82);
            panelManage.Size = new Size(1000, 600);
            lblHeader.Text = "Manage Rooms";
        }
        private void NavBar_FillRoom_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.Navy;
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);

            // isinya panel
            panelManage.Visible = false;
            panelFill.Visible = true;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            panelListrik.Visible = false;
            panelGuestLog.Visible = false;

            // nge set
            panelFill.Location = new Point(230, 82);
            panelFill.Size = new Size(1000, 600);
            lblHeader.Text = "Fill Room";
        }
        private void NavBar_Overview_Click(object sender, EventArgs e)
        {
            updateOverview();
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.Navy;
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);

            // ini ngeset isinya panel
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = true;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            panelListrik.Visible = false;
            panelGuestLog.Visible = false;

            // nge set
            panelOverview.Location = new Point(230, 82);
            panelOverview.Size = new Size(1000, 600);
            lblHeader.Text = "Overview";
        }
        private void NavBar_Laporan_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.Navy;
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);

            // ini isinya panel 
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = true;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            panelListrik.Visible = false;
            panelGuestLog.Visible = false;

            // nge set
            flowLayoutPanelComplaints.Location = new Point(230, 82);
            flowLayoutPanelComplaints.Size = new Size(1000, 600);
            lblHeader.Text = "Laporan";
            LoadDataFromDatabase();
        }
        private void NavBar_PenghuniDanTagihan_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.Navy;
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);

            // ini isinya panel nanti
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelKamar.Visible = false;
            panelPenghunidanTagihan.Visible = true;
            flowLayoutPanelPendapatan.Visible = false;
            panelListrik.Visible = false;
            panelGuestLog.Visible = false;

            // nge set
            panelPenghunidanTagihan.Location = new Point(230, 82);
            panelPenghunidanTagihan.Size = new Size(1000, 600);
            lblHeader.Text = "Penghuni dan Tagihan";
        }
        private void NavBar_Kamar_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.Navy;
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);

            // ini buat tampilin isi panelnya
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = true;
            flowLayoutPanelPendapatan.Visible = false;
            panelListrik.Visible = false;
            panelGuestLog.Visible = false;

            // nge set
            panelKamar.Location = new Point(230, 72);
            panelKamar.Size = new Size(1000, 600);
            flowLayoutPanelKamar.Size = new Size(800, 500);
            lblHeader.Text = "Kamar";
            LoadRoomCards();
        }

        private void NavBar_Pendapatan_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.Navy;

            // content
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = false;
            panelListrik.Visible = false;
            flowLayoutPanelPendapatan.Visible = true;
            panelGuestLog.Visible = false;

            flowLayoutPanelPendapatan.Location = new Point(230, 82);
            flowLayoutPanelPendapatan.Size = new Size(1000, 600);
            lblHeader.Text = "Laporan Pendapatan";
            LoadPendapatanFromDatabase();
        }
        private void NavBar_Listrik_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.Navy;

            // content
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            panelListrik.Visible = true;
            panelGuestLog.Visible = false;

            panelListrik.Location = new Point(230, 82);
            panelListrik.Size = new Size(1000, 600);
            lblHeader.Text = "Listrik Tenant";
            LoadListrikCards();
        }
        private void NavBar_GuestLog_Click(object sender, EventArgs e)
        {
            // panel btn
            panelBtnManage.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnFill.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnOverview.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnLaporan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPenghuni.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnKamar.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnPendapatan.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnListrik.BackColor = Color.FromArgb(0, 0, 64);
            panelBtnGuestLog.BackColor = Color.Navy;

            // content
            panelManage.Visible = false;
            panelFill.Visible = false;
            panelOverview.Visible = false;
            flowLayoutPanelComplaints.Visible = false;
            panelPenghunidanTagihan.Visible = false;
            panelKamar.Visible = false;
            flowLayoutPanelPendapatan.Visible = false;
            panelListrik.Visible = false;
            panelGuestLog.Visible = true;

            panelGuestLog.Location = new Point(230, 82);
            panelGuestLog.Size = new Size(1000, 600);
            lblHeader.Text = "Manage Tenant Guests";
            LoadGuestLogs();
        }
        private void CreateRoomCard(string roomNumber, string roomType, decimal price, string status, string facilities)
        {
            // MAIN CARD
            RoundedPanel card = new RoundedPanel();
            card.Width = 230;
            card.Height = 180;
            card.Margin = new Padding(5, 10, 10, 10);
            card.BorderColor = SystemColors.Control;

            // ROOM NAME
            Label lblName = new Label();
            lblName.Text = "Kamar " + roomNumber;
            lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblName.Location = new Point(10, 10);
            lblName.AutoSize = true;
            card.Controls.Add(lblName);

            // ROOM TYPE
            Label lblType = new Label();
            lblType.Text = roomType;
            lblType.Font = new Font("Segoe UI", 10);
            lblType.ForeColor = Color.DimGray;
            lblType.Location = new Point(10, 45);
            lblType.AutoSize = true;
            card.Controls.Add(lblType);

            // PRICE
            Label lblPrice = new Label();
            lblPrice.Text = "Rp " + price.ToString("N0");
            lblPrice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPrice.Location = new Point(10, 75);
            lblPrice.AutoSize = true;
            card.Controls.Add(lblPrice);

            // STATUS BADGE
            Label lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.AutoSize = true;
            lblStatus.Padding = new Padding(6);
            lblStatus.Location = new Point(card.Width - 100, 10);

            if (status == "Tersedia")
                lblStatus.BackColor = Color.FromArgb(80, 200, 120);
            else if (status == "Terisi")
                lblStatus.BackColor = Color.FromArgb(220, 80, 80);
            else
                lblStatus.BackColor = Color.FromArgb(255, 213, 79);

            lblStatus.ForeColor = Color.White;
            card.Controls.Add(lblStatus);

            // FACILITIES
            FlowLayoutPanel facilitiesPanel = new FlowLayoutPanel();
            facilitiesPanel.Location = new Point(10, 110);
            facilitiesPanel.Width = card.Width - 20;
            facilitiesPanel.Height = 60;
            facilitiesPanel.WrapContents = true;

            if (!string.IsNullOrWhiteSpace(facilities))
            {
                foreach (string f in facilities.Split(','))
                {
                    RoundedPanel chip = new RoundedPanel();
                    chip.BorderRadius = 8;
                    chip.BorderSize = 0;
                    chip.FillColor = Color.Gainsboro;
                    chip.Padding = new Padding(8, 4, 8, 4);
                    chip.AutoSize = true;
                    chip.MinimumSize = new Size(30, 23);
                    chip.Margin = new Padding(4);

                    Label lbl = new Label();
                    lbl.Text = f.Trim();
                    lbl.AutoSize = true;
                    lbl.Font = new Font("Segoe UI", 9);
                    lbl.BackColor = Color.Transparent;

                    chip.Controls.Add(lbl);

                    chip.SizeChanged += (s, e) =>
                    {
                        lbl.Location = new Point(
                            (chip.Width - lbl.Width) / 2,
                            (chip.Height - lbl.Height) / 2
                        );
                    };

                    facilitiesPanel.Controls.Add(chip);
                }
            }

            card.Controls.Add(facilitiesPanel);

            // EDIT BUTTON
            Button btnEdit = new Button();
            btnEdit.Text = "Edit";
            btnEdit.Width = 80;
            btnEdit.Height = 35;
            btnEdit.Location = new Point(card.Width - 100, card.Height - 110);

            btnEdit.Click += (s, e) =>
            {
                EditDetailRoom form = new EditDetailRoom(roomNumber, connectionString);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadRoomCards(); // refresh after edit
                }
            };

            card.Controls.Add(btnEdit);

            flowLayoutPanelKamar.Controls.Add(card);
        }

        private void CreateListrikCard(int billId, int leaseId, decimal pemakaianKwh, decimal tarifPerKwh, decimal totalTagihan, DateTime billMonth, string fullName, string paymentStatus, string adminStatus)
        {
            RoundedPanel card = new RoundedPanel();
            card.Width = 260;
            card.Height = 200;
            card.Margin = new Padding(5, 10, 10, 10);
            card.BorderColor = SystemColors.Control;

            // LEASE
            Label lblTenant = new Label();
            lblTenant.Text = "Lease ID: " + leaseId;
            lblTenant.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTenant.Location = new Point(10, 10);
            lblTenant.AutoSize = true;
            card.Controls.Add(lblTenant);

            // FULL NAME
            Label lblFullName = new Label();
            lblFullName.Text = "Tenant Name : " + fullName;
            lblFullName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblFullName.Location = new Point(10, 45);
            lblFullName.AutoSize = true;
            card.Controls.Add(lblFullName);

            // PEMAKAIAN
            Label lblPemakaian = new Label();
            lblPemakaian.Text = $"Pemakaian: {pemakaianKwh} kWh";
            lblPemakaian.Location = new Point(10, 70);
            lblPemakaian.AutoSize = true;
            card.Controls.Add(lblPemakaian);

            // TARIF
            Label lblTarif = new Label();
            lblTarif.Text = "Tarif: Rp " + tarifPerKwh.ToString("N0");
            lblTarif.Location = new Point(10, 95);
            lblTarif.AutoSize = true;
            card.Controls.Add(lblTarif);

            // TOTAL
            Label lblTotal = new Label();
            lblTotal.Text = "Total: Rp " + totalTagihan.ToString("N0");
            lblTotal.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTotal.Location = new Point(10, 125);
            lblTotal.AutoSize = true;
            card.Controls.Add(lblTotal);

            // BULAN
            Label lblBulan = new Label();
            lblBulan.Text = "Bulan: " + billMonth.ToString("MMMM yyyy");
            lblBulan.Location = new Point(10, 150);
            lblBulan.AutoSize = true;
            card.Controls.Add(lblBulan);

            // STATUS BADGE
            Label lblStatus = new Label();
            lblStatus.Text = "PAID";
            lblStatus.Padding = new Padding(6);
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(card.Width - 90, 10);
            lblStatus.ForeColor = Color.White;
            lblStatus.BackColor = Color.FromArgb(80, 200, 120); // hijau

            card.Controls.Add(lblStatus);


            // EDIT BUTTON
            Button btnEdit = new Button();
            btnEdit.Text = "Isi Token";
            btnEdit.Width = 90;
            btnEdit.Height = 35;
            btnEdit.Location = new Point(card.Width - 100, card.Height - 110);

            if (adminStatus == "Done")
            {
                btnEdit.Text = "DONE";
                btnEdit.Enabled = false;
                btnEdit.BackColor = Color.ForestGreen;
                btnEdit.ForeColor = Color.White;
            }
            else
            {
                btnEdit.Text = "ISI TOKEN";
                btnEdit.BackColor = Color.Orange;
                btnEdit.ForeColor = Color.Black;

                btnEdit.Click += (s, e) =>
                {
                    formIsiToken form = new formIsiToken(billId, connectionString);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadListrikCards(); // reload UI
                    }
                };
            }

            card.Controls.Add(btnEdit);

            flowLayoutPanelListrik.Controls.Add(card);
        }

        private void CreateGuestCard(int guestId, string guestName, string tenantName, DateTime visitDate, TimeSpan arrivalTime, DateTime? checkoutAt, string purpose)
        {
            RoundedPanel card = new RoundedPanel();
            card.Width = 260;
            card.Height = 180;
            card.Margin = new Padding(5, 10, 10, 10);
            card.BorderColor = SystemColors.Control;

            // GUEST NAME
            Label lblGuest = new Label();
            lblGuest.Text = guestName;
            lblGuest.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblGuest.Location = new Point(10, 10);
            lblGuest.AutoSize = true;
            card.Controls.Add(lblGuest);

            // TENANT NAME
            Label lblTenant = new Label();
            lblTenant.Text = "Tamu dari: " + tenantName;
            lblTenant.Font = new Font("Segoe UI", 9);
            lblTenant.ForeColor = Color.DimGray;
            lblTenant.Location = new Point(10, 40);
            lblTenant.AutoSize = true;
            card.Controls.Add(lblTenant);

            // DATE & TIME
            Label lblDateTime = new Label();
            lblDateTime.Text = checkoutAt == null
                ? $"{visitDate:dd MMM yyyy} • Masuk {arrivalTime:hh\\:mm}"
                : $"{visitDate:dd MMM yyyy} • {arrivalTime:hh\\:mm} - {checkoutAt.Value:HH:mm}";

            lblDateTime.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDateTime.Location = new Point(10, 65);
            lblDateTime.AutoSize = true;
            card.Controls.Add(lblDateTime);

            // PURPOSE
            Label lblPurpose = new Label();
            lblPurpose.Text = string.IsNullOrWhiteSpace(purpose)
                ? "Tujuan visit: -"
                : "Tujuan visit: " + purpose;

            lblPurpose.Font = new Font("Segoe UI", 9);
            lblPurpose.Location = new Point(10, 95);
            lblPurpose.MaximumSize = new Size(card.Width - 20, 0);
            lblPurpose.AutoSize = true;
            card.Controls.Add(lblPurpose);

            // CHECKOUT BUTTON (hanya kalau belum checkout)
            if (checkoutAt == null)
            {
                Button btnCheckout = new Button();
                btnCheckout.Text = "Checkout";
                btnCheckout.Width = 85;
                btnCheckout.Height = 32;
                btnCheckout.Location = new Point(card.Width - 95, card.Height - 45);

                btnCheckout.Click += (s, e) =>
                {
                    if (MessageBox.Show(
                        "Checkout guest ini?",
                        "Konfirmasi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CheckoutGuest(guestId);
                        LoadGuestLogs();
                    }
                };

                card.Controls.Add(btnCheckout);
            }

            // CHECKOUT TIME (hanya jika sudah checkout)
            if (checkoutAt != null)
            {
                Label lblCheckout = new Label();
                lblCheckout.Text = "Checkout jam: " + checkoutAt.Value.ToString("HH:mm");
                lblCheckout.Font = new Font("Segoe UI", 9, FontStyle.Italic);
                lblCheckout.ForeColor = Color.DimGray;
                lblCheckout.Location = new Point(10, lblPurpose.Bottom + 5);
                lblCheckout.AutoSize = true;

                card.Controls.Add(lblCheckout);
            }


            flowLayoutPanelGuestLog.Controls.Add(card);
        }


        private void LoadGuestLogs()
        {
            flowLayoutPanelGuestLog.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        g.guest_id,
                        g.guest_name,
                        g.visit_date,
                        g.arrival_time,
                        g.checkout_at,
                        g.purpose,
                        t.full_name AS tenant_name
                    FROM guest_logs g
                    JOIN tenants t ON g.tenant_id = t.tenant_id
                    ORDER BY g.created_at DESC;
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CreateGuestCard(
                                Convert.ToInt32(reader["guest_id"]),
                                reader["guest_name"].ToString(),
                                reader["tenant_name"].ToString(),
                                Convert.ToDateTime(reader["visit_date"]),
                                (TimeSpan)reader["arrival_time"],
                                reader["checkout_at"] == DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(reader["checkout_at"]),
                                reader["purpose"]?.ToString()
                            );

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading guest logs: " + ex.Message);
                }
            }
        }

        private void UpdateAdminStatus(int billId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            UPDATE listrik_bills
            SET admin_status = 'Done'
            WHERE bill_id = @billId
        ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billId", billId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void LoadRoomCards()
        {
            flowLayoutPanelKamar.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    room_number,
                    type,
                    base_price,
                    status,
                    IFNULL(facilities, '') AS facilities
                FROM rooms
                ORDER BY room_number
            ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CreateRoomCard(
                                reader["room_number"].ToString(),
                                reader["type"].ToString(),
                                Convert.ToDecimal(reader["base_price"]),
                                reader["status"].ToString(),
                                reader["facilities"].ToString()
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading room data: " + ex.Message);
                }
            }
        }

        private void LoadListrikCards()
        {
            flowLayoutPanelListrik.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            lb.bill_id,
                            lb.lease_id,
                            lb.pemakaian_kwh,
                            lb.tarif_per_kwh,
                            lb.total_tagihan,
                            lb.bill_month,
                            lb.status,
                            lb.admin_status,
                            t.full_name
                        FROM listrik_bills lb
                        JOIN leases l ON lb.lease_id = l.lease_id
                        JOIN tenants t ON l.tenant_id = t.tenant_id
                        WHERE lb.status = 'Paid'
                        ORDER BY lb.bill_month DESC;
                    ";


                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CreateListrikCard(
                                Convert.ToInt32(reader["bill_id"]),
                                Convert.ToInt32(reader["lease_id"]),
                                Convert.ToDecimal(reader["pemakaian_kwh"]),
                                Convert.ToDecimal(reader["tarif_per_kwh"]),
                                Convert.ToDecimal(reader["total_tagihan"]),
                                Convert.ToDateTime(reader["bill_month"]),
                                Convert.ToString(reader["full_name"]),
                                reader["status"].ToString(),
                                reader["admin_status"].ToString()
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading listrik data: " + ex.Message);
                }
            }
        }

        private void CheckoutGuest(int guestId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            UPDATE guest_logs
            SET checkout_at = NOW()
            WHERE guest_id = @id
              AND checkout_at IS NULL";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", guestId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void LoadDgvOverview()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT r.room_number,r.type,t.full_name FROM leases l JOIN rooms r ON r.room_id = l.room_id JOIN tenants t ON l.tenant_id = t.tenant_id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvManage.DataSource = dt;
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

        private void LoadDgvTagihan()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT \r\n    l.lease_id,\r\n    t.tenant_id,\r\n    t.full_name AS nama_penghuni,\r\n    r.room_number AS kamar,\r\n    l.start_date AS tgl_masuk,\r\n    MAX(tr.transaction_date) AS tagihan_terakhir,\r\n    CASE\r\n        WHEN l.status = 'Active' THEN 'AKTIF'\r\n        ELSE 'MENUNGGAK'\r\n    END AS STATUS\r\nFROM tenants t\r\nJOIN leases l ON t.tenant_id = l.tenant_id\r\nJOIN rooms r ON l.room_id = r.room_id\r\nLEFT JOIN transactions tr \r\n    ON tr.lease_id = l.lease_id \r\n    AND tr.status = 'Paid'\r\nGROUP BY \r\n    l.lease_id,\r\n    t.tenant_id,\r\n    t.full_name,\r\n    r.room_number,\r\n    l.start_date,\r\n    l.status\r\nORDER BY t.full_name;\r\n";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTagihan.DataSource = dt;
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

        private void CreateComplaintCard(int id, string category, string nama, string kamar, string tanggal, string pesan, string status)
        {
            // MAIN CARD
            RoundedPanel card = new RoundedPanel();
            card.Width = 850;
            card.Height = 210;
            card.BorderRadius = 20;
            card.BorderSize = 0;
            card.FillColor = Color.White;
            card.Margin = new Padding(15);

            // TITLE
            Label lblTitle = new Label();
            lblTitle.Text = category;
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            // SUBTITLE
            Label lblSub = new Label();
            lblSub.Text = $"{nama} · {kamar} · {tanggal}";
            lblSub.Font = new Font("Segoe UI", 9);
            lblSub.ForeColor = Color.Gray;
            lblSub.Location = new Point(20, 40);
            lblSub.AutoSize = true;
            card.Controls.Add(lblSub);

            // STATUS (Rounded)
            RoundedPanel statusPanel = new RoundedPanel();
            statusPanel.Width = 120;
            statusPanel.Height = 32;
            statusPanel.BorderRadius = 12;
            statusPanel.BorderSize = 0;
            statusPanel.FillColor = Color.FromArgb(255, 220, 220);
            statusPanel.Location = new Point(card.Width - 150, 20);

            ComboBox cmbStatus = new ComboBox();
            cmbStatus.Dock = DockStyle.Fill;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new string[] { "Menunggu", "Proses", "Selesai" });
            int statusIndex = cmbStatus.FindStringExact(status);
            cmbStatus.SelectedIndex = (statusIndex != -1) ? statusIndex : 0;
            if (status == "Selesai")
            {
                statusPanel.FillColor = Color.FromArgb(200, 255, 200);
                cmbStatus.ForeColor = Color.DarkGreen;
            }
            else if (status == "Proses")
            {
                statusPanel.FillColor = Color.FromArgb(255, 250, 200);
                cmbStatus.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                statusPanel.FillColor = Color.FromArgb(255, 220, 220);
                cmbStatus.ForeColor = Color.DarkRed;
            }
            cmbStatus.BackColor = statusPanel.FillColor;
            statusPanel.Controls.Add(cmbStatus);
            card.Controls.Add(statusPanel);

            // MESSAGE BUBBLE
            RoundedPanel msgPanel = new RoundedPanel();
            msgPanel.Width = card.Width - 40;
            msgPanel.Height = 45;
            msgPanel.Location = new Point(20, 70);
            msgPanel.BorderRadius = 12;
            msgPanel.BorderSize = 0;
            msgPanel.FillColor = Color.FromArgb(245, 245, 245);

            Label lblMsg = new Label();
            lblMsg.Text = pesan;
            lblMsg.Font = new Font("Segoe UI", 9);
            lblMsg.ForeColor = Color.Black;
            lblMsg.AutoSize = false;
            lblMsg.Dock = DockStyle.Fill;
            lblMsg.Padding = new Padding(10);

            msgPanel.Controls.Add(lblMsg);
            card.Controls.Add(msgPanel);

            // REPLY BOX
            RoundedPanel replyPanel = new RoundedPanel();
            replyPanel.Width = card.Width - 80;
            replyPanel.Height = 40;
            replyPanel.Location = new Point(20, 130);
            replyPanel.BorderRadius = 12;
            replyPanel.BorderSize = 0;
            replyPanel.FillColor = Color.FromArgb(50, 50, 50);

            TextBox txtReply = new TextBox();
            txtReply.BorderStyle = BorderStyle.None;
            txtReply.Multiline = true;
            txtReply.Dock = DockStyle.Fill;
            txtReply.ForeColor = Color.White;
            txtReply.BackColor = replyPanel.FillColor;
            txtReply.Font = new Font("Segoe UI", 9);
            //txtReply.Text = "Balasan admin...";
            txtReply.Padding = new Padding(8);

            replyPanel.Controls.Add(txtReply);
            card.Controls.Add(replyPanel);

            // SEND BUTTON
            Button btnSend = new Button();
            btnSend.Text = "➤";
            btnSend.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSend.Width = 40;
            btnSend.Height = 40;
            btnSend.Location = new Point(card.Width - 50, 130);
            btnSend.BackColor = Color.FromArgb(60, 120, 255);
            btnSend.ForeColor = Color.White;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.FlatAppearance.BorderSize = 0;



            btnSend.Click += (sender, e) =>
            {

                if (txtReply.Text == "")
                {
                    MessageBox.Show("Harap isi pesan balasan.");
                    return;
                }


                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateSql = "UPDATE complaints SET status = @status, admin_reply = @response, reply_at = @time WHERE complaint_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem);
                        cmd.Parameters.AddWithValue("@response", txtReply.Text);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@time", DateTime.Now);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Balasan terkirim dan status diperbarui.");
                            flowLayoutPanelComplaints.Controls.Remove(card);
                            LoadDataFromDatabase();
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengirim balasan. Silakan coba lagi.");
                        }
                    }
                }
            };



            card.Controls.Add(btnSend);

            flowLayoutPanelComplaints.Controls.Add(card);
        }

        private void CreatePendapatanCard(int id, string nama, string sumber, decimal jumlah, string metode, string tanggal, string status, string notes)
        {
            RoundedPanel card = new RoundedPanel();
            card.Width = 850;
            card.Height = 200;
            card.BorderRadius = 20;
            card.BorderSize = 0;
            card.FillColor = Color.White;
            card.Margin = new Padding(15);

            // TITLE
            Label lblTitle = new Label();
            lblTitle.Text = $"{nama} · {sumber}";
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            // SUBTITLE
            Label lblSub = new Label();
            lblSub.Text = $"{tanggal} · {metode}";
            lblSub.Font = new Font("Segoe UI", 9);
            lblSub.ForeColor = Color.Gray;
            lblSub.Location = new Point(20, 40);
            lblSub.AutoSize = true;
            card.Controls.Add(lblSub);

            // AMOUNT
            Label lblAmount = new Label();
            lblAmount.Text = "Rp " + Convert.ToInt32(jumlah).ToString("N0");
            lblAmount.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblAmount.ForeColor = Color.Black;
            lblAmount.Location = new Point(20, 70);
            lblAmount.AutoSize = true;
            card.Controls.Add(lblAmount);

            // STATUS PANEL
            RoundedPanel statusPanel = new RoundedPanel();
            statusPanel.Width = 150;
            statusPanel.Height = 32;
            statusPanel.BorderRadius = 12;
            statusPanel.BorderSize = 0;
            statusPanel.Location = new Point(card.Width - 180, 15);

            ComboBox cmbStatus = new ComboBox();
            cmbStatus.Dock = DockStyle.Fill;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new string[] { "Pending", "Paid", "Failed" });
            int sIdx = cmbStatus.FindStringExact(status);
            cmbStatus.SelectedIndex = (sIdx != -1) ? sIdx : 0;

            Color fill;
            Color textColor;
            if (cmbStatus.SelectedItem.ToString() == "Paid") { fill = Color.FromArgb(200, 255, 200); textColor = Color.DarkGreen; }
            else if (cmbStatus.SelectedItem.ToString() == "Pending") { fill = Color.FromArgb(255, 250, 200); textColor = Color.DarkGoldenrod; }
            else { fill = Color.FromArgb(255, 220, 220); textColor = Color.DarkRed; }
            statusPanel.FillColor = fill;
            cmbStatus.ForeColor = textColor;
            cmbStatus.BackColor = fill;
            statusPanel.Controls.Add(cmbStatus);
            card.Controls.Add(statusPanel);

            // NOTES PANEL
            RoundedPanel notesPanel = new RoundedPanel();
            notesPanel.Width = card.Width - 40;
            notesPanel.Height = 45;
            notesPanel.Location = new Point(20, 105);
            notesPanel.BorderRadius = 12;
            notesPanel.BorderSize = 0;
            notesPanel.FillColor = Color.FromArgb(245, 245, 245);

            Label lblNotes = new Label();
            lblNotes.Text = notes ?? "";
            lblNotes.Font = new Font("Segoe UI", 9);
            lblNotes.ForeColor = Color.Black;
            lblNotes.AutoSize = false;
            lblNotes.Dock = DockStyle.Fill;
            lblNotes.Padding = new Padding(10);

            notesPanel.Controls.Add(lblNotes);
            card.Controls.Add(notesPanel);

            // UPDATE BUTTON
            Button btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnUpdate.Width = 90;
            btnUpdate.Height = 32;
            btnUpdate.Location = new Point(card.Width - 110, 155);
            btnUpdate.BackColor = Color.FromArgb(60, 120, 255);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderSize = 0;

            btnUpdate.Click += (sender, e) =>
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateSql = "UPDATE transactions SET status = @status WHERE transaction_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem);
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Status pendapatan diperbarui.");
                            flowLayoutPanelPendapatan.Controls.Remove(card);
                            LoadPendapatanFromDatabase();
                        }
                        else
                        {
                            MessageBox.Show("Gagal memperbarui status.");
                        }
                    }
                }
            };

            card.Controls.Add(btnUpdate);

            flowLayoutPanelPendapatan.Controls.Add(card);
        }

        public DataTable GetData(string query)
        {
            //string connString = "Server=172.20.10.5;Database=cozy_corner_db;Uid=root;Pwd=;";
            string connString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Database: " + ex.Message);
                }
            }
            return dt;
        }

        private void autoUpdateJatuhTempo()
        {
            string connectionString = "server=172.20.10.5;user=root;database=nama_db;password=;";
            string query = "UPDATE tenants SET rent_due_by = DATE_ADD(rent_due_by, INTERVAL 1 MONTH) WHERE rent_due_by <= CURDATE()";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update masa sewa: " + ex.Message);
                }
            }
        }

        private void LoadDataFromDatabase()
        {

            flowLayoutPanelComplaints.Controls.Clear();

            string query = "SELECT c.complaint_id,c.category,t.full_name,r.room_number,c.created_at,c.description,c.status FROM complaints c JOIN tenants t ON c.tenant_id = t.tenant_id JOIN leases l ON c.tenant_id = l.tenant_id JOIN rooms r ON l.room_id = r.room_id WHERE c.status <> 'Selesai' ";

            DataTable dt = GetData(query);

            foreach (DataRow row in dt.Rows)
            {
                CreateComplaintCard(
                    Convert.ToInt32(row["complaint_id"]),
                    row["category"].ToString(),
                    row["full_name"].ToString(),
                    row["room_number"].ToString(),
                    row["created_at"].ToString(),
                    row["description"].ToString(),
                    row["status"].ToString()
                );
            }
        }

        private void LoadPendapatanFromDatabase()
        {
            flowLayoutPanelPendapatan.Controls.Clear();
            string query = @"SELECT tr.transaction_id, t.full_name, tr.category AS source, tr.amount, 
                                    tr.payment_method, tr.transaction_date AS paid_at, tr.status, tr.description AS notes
                              FROM transactions tr
                              JOIN leases l ON tr.lease_id = l.lease_id
                              JOIN tenants t ON l.tenant_id = t.tenant_id
                              ORDER BY tr.transaction_date DESC";

            DataTable dt = GetData(query);
            foreach (DataRow row in dt.Rows)
            {
                CreatePendapatanCard(
                    Convert.ToInt32(row["transaction_id"]),
                    row["full_name"].ToString(),
                    row["source"].ToString(),
                    row["amount"] != DBNull.Value ? Convert.ToDecimal(row["amount"]) : 0,
                    row["payment_method"].ToString(),
                    row["paid_at"].ToString(),
                    row["status"].ToString(),
                    row.Table.Columns.Contains("notes") ? row["notes"].ToString() : string.Empty
                );
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadComboBox()
        {
            string query = "SELECT * FROM rooms WHERE STATUS = 'Tersedia' ";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // 2. Gunakan MySqlDataAdapter untuk mengisi DataTable
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 3. Masukkan data ke ComboBox
                    comboRoomFill.DataSource = dt;


                    comboRoomFill.DisplayMember = "room_number";


                    comboRoomFill.ValueMember = "room_id";

                    comboRoomFill.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitFill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNama1.Text) || comboRoomFill.SelectedValue == null)
            {
                MessageBox.Show("Isi Data Terlebih Dahulu");
                return;
            }

            if (comboDurationFill.Value < 1)
            {
                MessageBox.Show("Durasi Sewa Minimal 1 Bulan");
                return;
            }

            string gender = radioWanita1.Checked ? "Perempuan" : "Laki-Laki";
            int tenantCount = checkBox4.Checked ? 2 : 1;

            // 🔑 PAYMENT TYPE
            string paymentType = radioSemuaBulan.Checked
                ? "IMMEDIATE"
                : "CONSECUTIVE";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction tr = conn.BeginTransaction())
                {
                    try
                    {
                        // =========================
                        // 1. GET BASE ROOM PRICE
                        // =========================
                        decimal basePrice;
                        using (MySqlCommand cmd = new MySqlCommand(
                            "SELECT base_price FROM rooms WHERE room_id = @id", conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@id", comboRoomFill.SelectedValue);
                            basePrice = Convert.ToDecimal(cmd.ExecuteScalar());
                        }

                        // =========================
                        // 2. APPLY 30% IF 2 PEOPLE
                        // =========================
                        decimal monthlyPrice = basePrice;
                        if (checkBox4.Checked)
                            monthlyPrice += monthlyPrice * 0.3m;

                        // =========================
                        // 3. INSERT USER
                        // =========================
                        long userId;
                        using (MySqlCommand c1 = new MySqlCommand(
                            "INSERT INTO users(username,password) VALUES(@u,'123')", conn, tr))
                        {
                            c1.Parameters.AddWithValue("@u", tbNama1.Text);
                            c1.ExecuteNonQuery();
                            userId = c1.LastInsertedId;
                        }

                        // =========================
                        // 4. INSERT MAIN TENANT
                        // =========================
                        long tenantId;
                        string qTenant = @"INSERT INTO tenants
                    (user_id, full_name, ktp_number, gender, date_of_birth, address)
                    VALUES (@u,@n,@k,@g,@d,@a)";

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

                        // =========================
                        // 5. INSERT SECOND TENANT
                        // =========================
                        if (checkBox4.Checked)
                        {
                            using (MySqlCommand c2b = new MySqlCommand(qTenant, conn, tr))
                            {
                                c2b.Parameters.AddWithValue("@u", userId);
                                c2b.Parameters.AddWithValue("@n", tbNama2.Text);
                                c2b.Parameters.AddWithValue("@k", tbNIK2.Text);
                                c2b.Parameters.AddWithValue("@g",
                                    radioWanita2.Checked ? "Perempuan" : "Laki-Laki");
                                c2b.Parameters.AddWithValue("@d", dateTimePicker2.Value);
                                c2b.Parameters.AddWithValue("@a", tbAlamat2.Text);
                                c2b.ExecuteNonQuery();
                            }
                        }

                        // =========================
                        // 6. INSERT LEASE
                        // =========================
                        DateTime startDate = DateTime.Today;

                        DateTime rentDue = paymentType == "CONSECUTIVE"
                            ? startDate.AddMonths(1)
                            : (DateTime?)null ?? startDate; // ignored for IMMEDIATE

                        DateTime endDate = startDate.AddMonths((int)comboDurationFill.Value);

                        long leaseId;
                        string qLease = @"INSERT INTO leases
                    (room_id, tenant_id, tenant_count, rent_price,
                     start_date, end_date, duration_months,
                     rent_due, payment_type)
                    VALUES
                    (@r,@t,@c,@p,@s,@e,@d,@due,@ptype)";

                        using (MySqlCommand c3 = new MySqlCommand(qLease, conn, tr))
                        {
                            c3.Parameters.AddWithValue("@r", comboRoomFill.SelectedValue);
                            c3.Parameters.AddWithValue("@t", tenantId);
                            c3.Parameters.AddWithValue("@c", tenantCount);
                            c3.Parameters.AddWithValue("@p", monthlyPrice);
                            c3.Parameters.AddWithValue("@s", startDate);
                            c3.Parameters.AddWithValue("@e", endDate);
                            c3.Parameters.AddWithValue("@d", comboDurationFill.Value);
                            c3.Parameters.AddWithValue(
                                "@due",
                                paymentType == "CONSECUTIVE"
                                    ? rentDue
                                    : (object)DBNull.Value
                            );
                            c3.Parameters.AddWithValue("@ptype", paymentType);
                            c3.ExecuteNonQuery();
                            leaseId = c3.LastInsertedId;
                        }

                        int duration = (int)comboDurationFill.Value;

                        // =========================
                        // 7. INSERT FIRST TRANSACTION
                        // =========================
                        decimal paymentAmount;
                        string description;

                        if (paymentType == "IMMEDIATE")
                        {
                            paymentAmount = monthlyPrice * duration;
                            description = $"Pembayaran Sewa {duration} Bulan (Lunas)";
                        }
                        else // CONSECUTIVE
                        {
                            paymentAmount = monthlyPrice;
                            description = $"Pembayaran Sewa Bulan ke-1 dari {duration}";
                        }

                        using (MySqlCommand c4 = new MySqlCommand(
                            @"INSERT INTO transactions
                          (lease_id, description, amount, status, category)
                          VALUES (@l, @desc, @amt, 'Paid', 'rent')",
                            conn, tr))
                        {
                            c4.Parameters.AddWithValue("@l", leaseId);
                            c4.Parameters.AddWithValue("@desc", description);
                            c4.Parameters.AddWithValue("@amt", paymentAmount);
                            c4.ExecuteNonQuery();
                        }


                        // =========================
                        // 8. UPDATE ROOM STATUS
                        // =========================
                        using (MySqlCommand c5 = new MySqlCommand(
                            "UPDATE rooms SET status='Terisi' WHERE room_id=@r", conn, tr))
                        {
                            c5.Parameters.AddWithValue("@r", comboRoomFill.SelectedValue);
                            c5.ExecuteNonQuery();
                        }

                        tr.Commit();
                        MessageBox.Show("Data berhasil disimpan!");
                        reset();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show("Transaksi Gagal: " + ex.Message);
                    }
                }
            }
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            gbOccupant2Fill.Enabled = false;
        }

        private void reset()
        {
            tbNama1.Text = "";
            tbNIK1.Text = "";
            tbAlamat1.Text = "";
            tbNama2.Text = "";
            tbNIK2.Text = "";
            tbAlamat2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            radioWanita1.Checked = true;
            radioWanita2.Checked = true;
            checkBox4.Checked = false;
            checkBox2.Checked = false;
            comboRoomFill.SelectedIndex = -1;
        }

        private void comboRoomFill_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanelLaporan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateOverview()
        {
            string terisi1 = "";
            string kosong1 = "";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string orang = "SELECT COUNT(lease_id) FROM leases WHERE STATUS = 'Active' ";
                    using (MySqlCommand cmd = new MySqlCommand(orang, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        label44.Text = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string complain = "SELECT COUNT(complaint_id) FROM complaints WHERE STATUS = 'Menunggu' ";
                    using (MySqlCommand cmd = new MySqlCommand(complain, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        label46.Text = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string kamar = "SELECT COUNT(room_id) FROM rooms ";
                    using (MySqlCommand cmd = new MySqlCommand(kamar, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        label40.Text = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string terisi = "SELECT COUNT(room_id) FROM rooms WHERE STATUS = 'Terisi' ";
                    using (MySqlCommand cmd = new MySqlCommand(terisi, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        terisi1 = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string kosong = "SELECT COUNT(room_id) FROM rooms WHERE STATUS = 'Tersedia' ";
                    using (MySqlCommand cmd = new MySqlCommand(kosong, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        kosong1 = (res != null && res != DBNull.Value) ? Convert.ToString(res) : "0";
                        label39.Text = terisi1.ToString() + " Terisi / " + kosong1.ToString() + " Kosong";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error: " + ex.Message);
                }
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        private void GetDataByFullName(string name)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tenants t JOIN leases l ON t.tenant_id = l.tenant_id WHERE t.full_name = @name";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        namaHuni1.Text = row["full_name"].ToString();
                        ktpHuni1.Text = row["ktp_number"].ToString();

                        if (row["date_of_birth"] != DBNull.Value)
                            tglHuni1.Text = Convert.ToDateTime(row["date_of_birth"]).ToString("dd MMM yyyy");

                        genderHuni1.Text = row["gender"].ToString();
                        lblDuration.Text = row["duration_months"].ToString() + " Months";
                        lblRentDue.Text = row["end_date"].ToString();

                        if (row["start_date"] != DBNull.Value)
                            lblSince.Text = Convert.ToDateTime(row["start_date"]).ToString("dd/MM/yyyy");

                        if (Convert.ToInt32(row["tenant_count"]) == 2)
                        {
                            roundedPanelOccupant2.Visible = true;
                            GetSecondTenant(row["user_id"].ToString(), row["full_name"].ToString());
                        }
                        else
                        {
                            roundedPanelOccupant2.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void GetSecondTenant(string userId, string excludedName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tenants WHERE user_id = @uid AND full_name <> @excludedName LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@excludedName", excludedName);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row2 = dt.Rows[0];
                        namaHuni2.Text = row2["full_name"].ToString();
                        ktpHuni2.Text = row2["ktp_number"].ToString();

                        if (row2["date_of_birth"] != DBNull.Value)
                            tglHuni2.Text = Convert.ToDateTime(row2["date_of_birth"]).ToString("dd MMM yyyy");

                        genderHuni2.Text = row2["gender"].ToString();
                    }
                    else
                    {
                        roundedPanelOccupant2.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void GetRoomIdByNumber(int roomNumber)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT room_id FROM rooms WHERE room_number = @roomNumber";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@roomNumber", roomNumber);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        roomId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void loadDgvNotif()
        {
            string query = "SELECT id,title, content FROM announcements LIMIT 5";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvNotification.DataSource = dt;
                    dgvNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            // --- 1. Basic Styling (Tampilan Modern Flat) ---
            dgvNotification.BackgroundColor = Color.White;
            dgvNotification.BorderStyle = BorderStyle.None;
            dgvNotification.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNotification.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvNotification.RowHeadersVisible = false; // Sembunyikan selector baris kiri
            dgvNotification.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // --- 2. Header Style ---
            dgvNotification.EnableHeadersVisualStyles = false;
            dgvNotification.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48); // Warna gelap modern
            dgvNotification.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNotification.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvNotification.ColumnHeadersHeight = 40;

            // --- 3. Row Style ---
            dgvNotification.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240); // Abu muda saat dipilih
            dgvNotification.DefaultCellStyle.SelectionForeColor = Color.Black; // Teks tetap hitam
            dgvNotification.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvNotification.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvNotification.DefaultCellStyle.Padding = new Padding(8); // Jarak teks biar tidak mepet
            dgvNotification.RowTemplate.Height = 35;

            // Alternating Row Color (Baris selang-seling)
            dgvNotification.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            // --- 4. Tambah Tombol Delete ---
            // Cek dulu biar kolom tidak double kalau method dipanggil ulang
            if (!dgvNotification.Columns.Contains("colDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "colDelete";
                btnDelete.HeaderText = ""; // Header kosong
                btnDelete.Text = "Hapus";
                btnDelete.UseColumnTextForButtonValue = true; // Munculkan teks "Hapus" di tombol

                // Style tombol agar terlihat flat (teks merah)
                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.DefaultCellStyle.ForeColor = Color.Red;
                btnDelete.DefaultCellStyle.SelectionForeColor = Color.Red;

                // Tambahkan di kolom paling akhir
                dgvNotification.Columns.Add(btnDelete);
            }

            dgvNotification.AllowUserToAddRows = false;
            dgvNotification.AllowUserToDeleteRows = false;
            dgvNotification.ReadOnly = true;
        }


        private void dgvManage_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            roundedPanelOccupant2.Visible = false;
            if (e.RowIndex >= 0)
            {
                string fullName = dgvManage.Rows[e.RowIndex].Cells[2].Value.ToString();
                GetDataByFullName(fullName);
                roomNum = Convert.ToInt32(dgvManage.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void btnUnoccupy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus data sewa dan ubah status kamar menjadi Tersedia?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        MySqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string queryUpdate = "UPDATE rooms SET status = 'Tersedia' WHERE room_number = @room_id";
                            MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn, transaction);
                            cmdUpdate.Parameters.AddWithValue("@room_id", roomNum);
                            cmdUpdate.ExecuteNonQuery();

                            GetRoomIdByNumber(roomNum);
                            string queryDelete = "DELETE FROM leases WHERE room_id = @room_id";
                            MySqlCommand cmdDelete = new MySqlCommand(queryDelete, conn, transaction);
                            cmdDelete.Parameters.AddWithValue("@room_id", roomId);
                            cmdDelete.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Proses berhasil dilakukan.");
                            LoadDgvOverview();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Transaksi gagal: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Koneksi: " + ex.Message);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dgvTagihan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedLeaseId = Convert.ToInt32(
                    dgvTagihan.Rows[e.RowIndex].Cells["lease_id"].Value
                );
                //MessageBox.Show("ini cell content click, lease id: " + selectedLeaseId);
            }
        }

        private void dgvTagihan_DoubleClick(object sender, EventArgs e)
        {
            // this is buat nyetak nota per orang
        }

        private void dgvTagihan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedLeaseId = Convert.ToInt32(
                    dgvTagihan.Rows[e.RowIndex].Cells["lease_id"].Value
                );
                //MessageBox.Show("ini cell click, lease id: " + selectedLeaseId);
            }

        }

        private void btnTambahKamar_Click(object sender, EventArgs e)
        {
            formCreateKamar formBikinKamar = new formCreateKamar(connectionString);
            if (formBikinKamar.ShowDialog() == DialogResult.OK)
            {
                LoadRoomCards();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            // Open FormNota with notaGroup report (all transactions grouped)
            // Parameters: id=0, title, isGroupReport=true
            FormNota formNota = new FormNota(0, "Laporan Semua Transaksi", true);
            formNota.ShowDialog();
        }

        private void buttonSendReminderKeTenant_Click(object sender, EventArgs e)
        {
            if (dgvTagihan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih tenant terlebih dahulu!");
                return;
            }

            // Ambil row yang dipilih
            DataGridViewRow row = dgvTagihan.SelectedRows[0];

            int tenantId = Convert.ToInt32(row.Cells["tenant_id"].Value);
            MessageBox.Show("tenant id: " + tenantId);

            string title = "Pengingat Pembayaran";
            string content = "Reminder bayar uang sewa"; // bisa custom nanti

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            INSERT INTO reminders (title, content, tenant_id)
            VALUES (@title, @content, @tenantId)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Reminder berhasil dikirim ke tenant!");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            addPengumuman.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addPengumuman.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Isi Data Terlebih Dahulu");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                INSERT INTO announcements (title, content)
                VALUES (@title, @content)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", textBox1.Text);
                    cmd.Parameters.AddWithValue("@content", textBox2.Text);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("announcement berhasil dibuat!");
            addPengumuman.Visible = false;
            loadDgvNotif();

        }

        private void buttonTagihKerusakanFailitas_Click(object sender, EventArgs e)
        {

            if (dgvTagihan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih tenant terlebih dahulu!");
                return;
            }

            // Ambil row yang dipilih
            DataGridViewRow row = dgvTagihan.SelectedRows[0];

            int tenantId = Convert.ToInt32(row.Cells["tenant_id"].Value);
            //MessageBox.Show("tenant id: " + tenantId);

            formTagihan form = new formTagihan(tenantId, connectionString);
            form.ShowDialog();

        }

        private void labelUserLogout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void comboDurationFill_ValueChanged(object sender, EventArgs e)
        {

            refreshTotalPembayaran();

        }

        private void radioSemuaBulan_CheckedChanged(object sender, EventArgs e)
        {

            refreshTotalPembayaran();
        }

        private void radioPerBulan_CheckedChanged(object sender, EventArgs e)
        {

            refreshTotalPembayaran();
        }

        private void refreshTotalPembayaran()
        {
            decimal hargaKamar = 0;
            string query = "Select base_price from rooms where room_id = @param";
            if (radioSemuaBulan.Checked)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@param", comboRoomFill.SelectedValue);
                        object res = cmd.ExecuteScalar();
                        hargaKamar = (res != null && res != DBNull.Value) ? Convert.ToDecimal(res) : 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghitung pembayaran: " + ex.Message);
                    }
                    decimal totalPembayaran = hargaKamar * (int)comboDurationFill.Value;
                    lblFillPembayaran.Text = totalPembayaran.ToString();
                }
            }
            else if (radioPerBulan.Checked)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@param", comboRoomFill.SelectedValue);
                        object res = cmd.ExecuteScalar();
                        hargaKamar = (res != null && res != DBNull.Value) ? Convert.ToDecimal(res) : 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghitung pembayaran: " + ex.Message);
                    }
                    decimal totalPembayaran = hargaKamar;
                    lblFillPembayaran.Text = totalPembayaran.ToString();
                }
            }

            if (checkBox4.Checked)
            {
                decimal tambahan = hargaKamar * 0.3m;
                decimal currentTotal = decimal.Parse(lblFillPembayaran.Text);
                lblFillPembayaran.Text = (currentTotal + tambahan).ToString();
            }
        }

        private void dgvNotification_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNotification.Columns[e.ColumnIndex].Name == "colDelete")
            {
                int id = Convert.ToInt32(dgvNotification.Rows[e.RowIndex].Cells["id"].Value);

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string query = "DELETE FROM announcements WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id); // Pakai parameter biar aman

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil dihapus");

                            loadDgvNotif();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LaporanFer laporan = new LaporanFer();
            laporan.ShowDialog();
        }

        private void panelBtnFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


            if(dateTimePicker3.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Tanggal masuk tidak boleh kurang dari hari ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime tglMasuk = dateTimePicker3.Value.Date;
            int durasi = (int)numericUpDown1.Value;
            DateTime tglKeluar = tglMasuk.AddMonths(durasi);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // LOGIKA QUERY:
                    // Ambil semua kamar dari tabel 'rooms'
                    // KECUALI kamar yang ada di tabel 'leases' dengan status Active/Booked
                    // DAN tanggal sewanya BENTROK dengan tanggal yang kita cari.

                    string query = @"
                    SELECT 
                        r.room_id, 
                        r.room_number AS 'Nomor Kamar', 
                        r.type AS 'Tipe', 
                        r.base_price AS 'Harga',
                        r.facilities AS 'Fasilitas'
                    FROM rooms r
                    WHERE r.status != 'Perbaikan' -- Pastikan kamar tidak rusak
                    AND r.room_id NOT IN (
                        SELECT l.room_id 
                        FROM leases l 
                        WHERE l.status IN ('Active', 'Booked')
                        AND (
                            (l.start_date < @tglKeluar AND l.end_date > @tglMasuk)
                        )
                    )
                    ORDER BY r.room_number ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tglMasuk", tglMasuk);
                    cmd.Parameters.AddWithValue("@tglKeluar", tglKeluar);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvKamar.DataSource = dt;

                    // Sembunyikan ID
                    if (dgvKamar.Columns.Contains("room_id"))
                        dgvKamar.Columns["room_id"].Visible = false;

                    // Format Rupiah
                    if (dgvKamar.Columns.Contains("Harga"))
                        dgvKamar.Columns["Harga"].DefaultCellStyle.Format = "N0";


                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak ada kamar tersedia pada tanggal tersebut.", "Penuh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            StyleGridKamar();
        }

        private void dgvKamar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKamar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil ID (Hidden column)
                int roomId = Convert.ToInt32(dgvKamar.CurrentRow.Cells["room_id"].Value);

                // Ambil Nomor Kamar
                string noKamar = dgvKamar.CurrentRow.Cells["Nomor Kamar"].Value.ToString();

                // Ambil Harga (Convert object ke decimal)
                decimal harga = Convert.ToDecimal(dgvKamar.CurrentRow.Cells["Harga"].Value);

                // --- 3. AMBIL DATA DARI INPUT FILTER ---
                DateTime tglMasuk = dateTimePicker3.Value.Date;
                int durasi = (int)numericUpDown1.Value;

                // --- 4. BUKA FORM ISI DATA ---
                // Kita passing data-data tersebut ke Constructor isiData
                isiData formIsi = new isiData(roomId, noKamar, harga, tglMasuk, durasi);

                // Gunakan ShowDialog() agar user fokus mengisi data dan tidak bisa klik form belakang
                formIsi.ShowDialog();


                // Setelah form isiData ditutup, kita bisa refresh data kamar lagi
                dateTimePicker3.Value = DateTime.Now;
                numericUpDown1.Value = 1;
                dgvKamar.DataSource = null;

            }
        }


        private void StyleGridKamar()
        {
            // --- 1. TAMPILAN DASAR ---
            dgvKamar.BorderStyle = BorderStyle.None;
            dgvKamar.BackgroundColor = Color.White; // Background putih bersih
            dgvKamar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Garis horizontal tipis
            dgvKamar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; // Hilangkan border header

            // Non-aktifkan visual style bawaan Windows agar warna custom bekerja
            dgvKamar.EnableHeadersVisualStyles = false;

            // --- 2. HEADER (JUDUL KOLOM) ---
            dgvKamar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48); // Abu Gelap
            dgvKamar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Tulisan Putih
            dgvKamar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Font Tebal
            dgvKamar.ColumnHeadersHeight = 45; // Header agak tinggi biar lega
            dgvKamar.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0); // Padding teks header

            // --- 3. ISI BARIS (ROWS) ---
            dgvKamar.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvKamar.DefaultCellStyle.SelectionBackColor = Color.SeaGreen; // Warna saat dipilih (Hijau)
            dgvKamar.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvKamar.DefaultCellStyle.Padding = new Padding(6, 4, 0, 4); // Spasi dalam sel
            dgvKamar.RowTemplate.Height = 35; // Tinggi baris

            // Warna Selang-seling (Zebra)
            dgvKamar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); // Abu sangat muda

            // --- 4. BEHAVIOR ---
            dgvKamar.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Pilih satu baris penuh
            dgvKamar.MultiSelect = false; // Hanya boleh pilih 1 kamar
            dgvKamar.ReadOnly = true; // Tidak bisa diedit langsung
            dgvKamar.AllowUserToAddRows = false; // Hilangkan baris kosong di bawah
            dgvKamar.RowHeadersVisible = false; // Hilangkan selector jelek di kiri
            dgvKamar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Lebar kolom menyesuaikan

            // --- 5. FORMAT KHUSUS PER KOLOM ---
            // Pastikan nama kolom sesuai dengan Query SQL Anda

            // Rata Tengah untuk Tipe & Nomor
            if (dgvKamar.Columns.Contains("Nomor Kamar"))
            {
                dgvKamar.Columns["Nomor Kamar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvKamar.Columns["Nomor Kamar"].Width = 100;
                dgvKamar.Columns["Nomor Kamar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvKamar.Columns.Contains("Tipe"))
            {
                dgvKamar.Columns["Tipe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvKamar.Columns["Tipe"].Width = 100;
            }

            // Rata Kanan untuk Harga (Format Uang)
            if (dgvKamar.Columns.Contains("Harga"))
            {
                dgvKamar.Columns["Harga"].DefaultCellStyle.Format = "N0"; // Rp 1.000.000
                dgvKamar.Columns["Harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvKamar.Columns["Harga"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Tebalkan Font Harga
                dgvKamar.Columns["Harga"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvKamar.Columns["Harga"].DefaultCellStyle.ForeColor = Color.DarkGreen;
            }

            // Sembunyikan ID (Tidak perlu dilihat user)
            if (dgvKamar.Columns.Contains("room_id"))
            {
                dgvKamar.Columns["room_id"].Visible = false;
            }
        }
    }
}
