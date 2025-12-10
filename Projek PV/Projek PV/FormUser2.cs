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
    public partial class FormUser2 : Form
    {
        public FormUser2()
        {
            InitializeComponent();
        }

        private void NavBarUser_Overview(object sender, EventArgs e)
        {

        }
        private void NavBarUser_ExtendDuration(object sender, EventArgs e)
        {

        }
        private void NavBarUser_Complaint(object sender, EventArgs e)
        {
            panelUserComplaint.Visible = true;
        }

    }
}
