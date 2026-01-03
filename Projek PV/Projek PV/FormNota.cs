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
    public partial class FormNota : Form
    {
        private int transactionId;
        private string reportTitle;

        public FormNota()
        {
            InitializeComponent();
            transactionId = 0;
            reportTitle = "Nota Transaksi";
        }

        public FormNota(int id)
        {
            InitializeComponent();
            transactionId = id;
            reportTitle = "Nota Transaksi";
        }

        public FormNota(int id, string title)
        {
            InitializeComponent();
            transactionId = id;
            reportTitle = title;
        }

        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        private void FormNota_Load(object sender, EventArgs e)
        {
            this.Text = reportTitle;
            loadCrystalReport();
        }

        private void loadCrystalReport()
        {
            try
            {
                DataSet ds = new DataSet();

                DataTable dtTransaction = new DataTable("DataTablePerpanjang");
                string queryTransaction = "SELECT tr.transaction_id, tr.lease_id, tr.transaction_date, tr.description, " +
                                        "tr.discount, tr.amount, tr.payment_method, tr.status, tr.category, " +
                                        "t.full_name, r.room_number " +
                                        "FROM transactions tr " +
                                        "JOIN leases l ON tr.lease_id = l.lease_id " +
                                        "JOIN tenants t ON l.tenant_id = t.tenant_id " +
                                        "JOIN rooms r ON l.room_id = r.room_id " +
                                        "WHERE tr.transaction_id = @transaction_id";

                using(MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    using(MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryTransaction, conn))
                    {
                        cmd.Parameters.AddWithValue("@transaction_id", transactionId);
                        using(MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd))
                        {
                            conn.Open();
                            adapter.Fill(dtTransaction);
                            
                        }
                    }
                }
                ds.Tables.Add(dtTransaction);

                notaPerpanjang cr = new notaPerpanjang();
                cr.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cr;
                crystalReportViewer1.Refresh();
            }catch(Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message);
            }

        }
    }
}
