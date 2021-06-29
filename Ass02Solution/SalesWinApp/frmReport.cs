using BusinessObjects;
using DataAccess.Repository;
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
    public partial class frmReport : Form
    {
        public Member member { get; set; }
        private DataTable dt;
        private IOrderRepository repository = new OrderRepository();
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if(member == null)
            {
                dt = repository.GetOrdersByDate(start, end);
            }
            else
            {
                dt = repository.GetOrdersByMember(member);
            }
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("No Data");
                Close();
                return;
            }
            DataGridView dgvOrders = new DataGridView();
            dgvOrders.DataSource = dt;
            dgvOrders.Width = this.Width;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AllowUserToResizeRows = false;
            dgvOrders.AllowUserToResizeColumns = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Location = new Point((this.Width - dgvOrders.Width)/ 2,(this.Height - dgvOrders.Height)/2);
            this.Controls.Add(dgvOrders);
            decimal totalIncome = decimal.Parse(dt.Compute("SUM(Total)", "").ToString());
            lbTotal.Text = $"Total: {totalIncome}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
