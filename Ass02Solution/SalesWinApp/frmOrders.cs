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
    public partial class frmOrders : Form
    {
        private IOrderRepository Repo = new OrderRepository();
        private DataTable dtOrder = null;
        public frmOrders()
        {
            InitializeComponent();
        }

        private void LoadOrders()
        {
            dtOrder = new DataTable();
            dtOrder = Repo.GetOrders();
            dtOrder.PrimaryKey = new DataColumn[] { dtOrder.Columns["OrderId"] };
            dgvOrderList.DataSource = null;
            dgvOrderList.DataSource = dtOrder;
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            frmOrderDetails detailsForm = new frmOrderDetails
            {
                Text = "Order Details",
                orderID = (int)dgvOrderList.CurrentRow.Cells[0].Value,
                InsertOrUpdate = true
            };
            detailsForm.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var orders = Repo.GetOrders();
            int orderID = 0;
            if(orders.Rows.Count >= 1)
            {
                orderID = int.Parse(orders.Compute("MAX(OrderId)", "").ToString()) + 1;
            }
            frmOrderDetails frmDetails = new frmOrderDetails
            {
                Text = "New Order",
                InsertOrUpdate = false,
                orderID = orderID
            };
            frmDetails.ShowDialog();
            if(frmDetails.DialogResult == DialogResult.OK)
            {
                LoadOrders();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This action will removes all details of this order. Are you sure ?", "Remove confirmation", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                try
                {
                    DataRow row = dtOrder.Rows.Find(int.Parse(dgvOrderList.CurrentRow.Cells[0].Value.ToString()));
                    int id = (int)row["OrderId"];
                    Order ord = Repo.GetOrderByID(id);
                new OrderDetailRepository().RemoveByOrder(ord);
                    dtOrder.Rows.Remove(row);
                    Repo.DeleteOrder(ord);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
