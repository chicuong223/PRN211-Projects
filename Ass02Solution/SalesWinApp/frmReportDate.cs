using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmReportDate : Form
    {
        public frmReportDate()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport
            {
                start = dateStart.Value,
                end = dateEnd.Value
            };
            report.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmReportDate_Load(object sender, EventArgs e)
        {
            dateStart.Format = DateTimePickerFormat.Custom;
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateStart.CustomFormat = "dd/MMM/yyyy";
            dateEnd.CustomFormat = "dd/MMM/yyyy";
        }
    }
}
