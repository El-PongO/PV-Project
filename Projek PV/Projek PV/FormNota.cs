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

        public FormNota()
        {
            InitializeComponent();
            transactionId = 0;
        }

        public FormNota(int id)
        {
            InitializeComponent();
            transactionId = id;
        }

        string connectionString = "Server=localhost;Database=cozy_corner_db;Uid=root;Pwd=;";

        private void FormNota_Load(object sender, EventArgs e)
        {
            loadCrystalReport();
        }

        private void loadCrystalReport()
        {
            try
            {
                DataSet ds = new DataSet();

                DataTable dtPerpanjang = new DataTable("DataTablePerpanjang");
                string queryPerpanjang = "SELECT tr.transaction_id, tr.lease_id, tr.transaction_date, tr.description, " +
                                        "tr.discount, tr.amount, tr.payment_method, tr.status, tr.category, " +
                                        "t.full_name, r.room_number " +
                                        "FROM transactions tr " +
                                        "JOIN leases l ON tr.lease_id = l.lease_id " +
                                        "JOIN tenants t ON l.tenant_id = t.tenant_id " +
                                        "JOIN rooms r ON l.room_id = r.room_id " +
                                        "WHERE tr.transaction_id = @transaction_id";

                using(MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    using(MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryPerpanjang, conn))
                    {
                        cmd.Parameters.AddWithValue("@transaction_id", transactionId);
                        using(MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd))
                        {
                            conn.Open();
                            adapter.Fill(dtPerpanjang);
                            
                        }
                    }
                }
                ds.Tables.Add(dtPerpanjang);

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
