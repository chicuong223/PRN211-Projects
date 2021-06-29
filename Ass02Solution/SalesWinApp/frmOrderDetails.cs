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
    public partial class frmOrderDetails : Form
    {
        private IOrderDetailRepository DetailRepo = new OrderDetailRepository();
        private IOrderRepository OrderRepo = new OrderRepository();
        private Order order = new Order();
        public DataTable dt;
        public int orderID;
        public bool InsertOrUpdate { get; set; }
        public frmOrderDetails()
        {
            InitializeComponent();
        }

        private void AddComboMember()
        {
            IMemberRepository memberRepository = new MemberRepository();
            var members = memberRepository.GetMembers();
            foreach (Member member in members)
            {
                cboMemberID.Items.Add(member.MemberId);
            }
        }

        private void LoadDetails()
        {
            dt = DetailRepo.GetDetails(orderID);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductId"] };
            bsDetail.DataSource = dt;
            dgvDetailList.DataSource = bsDetail;
            bsDetail.Sort = "ProductId DESC";
        }


        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            LoadDetails();
            AddComboMember();
            if (InsertOrUpdate == true)
            {
                order = OrderRepo.GetOrderByID(orderID);
                cboMemberID.Text = order.MemberId.ToString();
                txtFeight.Text = order.Freight.ToString();
                dateOrder.Value = order.OrderDate;
                dateRequire.Value = (DateTime)order.RequiredDate;
                dateShipped.Value = (DateTime)order.ShippedDate;
            }
            lbOrderID.Text = $"Order ID: {orderID}";
            if (dt.Rows.Count < 1)
            {
                btnRemove.Enabled = false;
                btnView.Enabled = false;
            }
            else
            {
                btnRemove.Enabled = true;
                btnView.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataRow row = dt.Rows.Find(int.Parse(dgvDetailList.CurrentRow.Cells[0].Value.ToString()));
            dt.Rows.Remove(row);
            dgvDetailList.DataSource = null;
            dgvDetailList.Refresh();
            dgvDetailList.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Please choose at least 1 product");
                }
                order = new Order
                {
                    OrderId = orderID,
                    MemberId = int.Parse(cboMemberID.Text),
                    OrderDate = dateOrder.Value,
                    RequiredDate = dateRequire.Value,
                    ShippedDate = dateShipped.Value,
                    Freight = decimal.Parse(txtFeight.Text)
                };
                if (InsertOrUpdate == false)
                {
                    OrderRepo.AddOrder(order);
                }
                else
                {
                    OrderRepo.UpdateOrder(order);
                }

                DetailRepo.RemoveByOrder(order);

                foreach (DataRow row in dt.Rows)
                {
                    OrderDetail detail = new OrderDetail
                    {
                        OrderId = orderID,
                        ProductId = (int)row["ProductId"],
                        Discount = (double)row["Discount"],
                        Quantity = (int)row["Quantity"],
                        UnitPrice = (decimal)row["UnitPrice"]
                    };
                    DetailRepo.AddDetail(detail);
                }
                MessageBox.Show("Success");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult = DialogResult.None;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataRow row = dt.Rows.Find(int.Parse(dgvDetailList.CurrentRow.Cells[0].Value.ToString()));
            frmAddDetail frmAddDetail = new frmAddDetail
            {
                AddOrUpdate = true,
                productID = (int)row["ProductId"],
                productName = row["ProductName"].ToString(),
                price = (decimal)row["UnitPrice"],
                quantity = (int)row["Quantity"],
                discount = (double)row["Discount"]
            };
            frmAddDetail.ShowDialog();
            if (frmAddDetail.DialogResult == DialogResult.OK)
            {
                DataRow dtrow = dt.Rows.Find(frmAddDetail.productID);
                dtrow["UnitPrice"] = frmAddDetail.price;
                dtrow["Quantity"] = frmAddDetail.quantity;
                dtrow["Discount"] = frmAddDetail.discount;
                decimal finalRate = (decimal)(1 - frmAddDetail.discount);
                dtrow["Subtotal"] = frmAddDetail.price * frmAddDetail.quantity * finalRate;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddDetail frmDetail = new frmAddDetail
            {
                AddOrUpdate = false
            };
            frmDetail.ShowDialog();
            if (frmDetail.DialogResult == DialogResult.OK)
            {
                try
                {
                    int productID = frmDetail.productID;
                    int quantity = frmDetail.quantity;
                    double discount = frmDetail.discount;
                    decimal price = frmDetail.price;
                    string productName = frmDetail.productName;
                    decimal finalPrice = (decimal)(1 - discount);
                    decimal subtotal = quantity * price * finalPrice;
                    dt.Rows.Add(productID, productName, price, quantity, discount, subtotal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This product ID is already in this order");
                }
            }
            if (btnRemove.Enabled == false && btnView.Enabled == false)
            {
                btnRemove.Enabled = true;
                btnView.Enabled = true;
            }
        }
    }
}
