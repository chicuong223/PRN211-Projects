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
    public partial class frmAddDetail : Form
    {
        private IProductRepository ProductRepository = new ProductRepository();
        public int productID { get; set; }
        public int quantity { get; set; }
        public double discount { get; set; }
        public decimal price { get; set; }
        public string productName { get; set; }
        public bool AddOrUpdate { get; set; }
        public frmAddDetail()
        {
            InitializeComponent();
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pros = ProductRepository.GetProductsByName(cboProduct.Text);
            foreach(Product pro in pros)
            {
                txtProductID.Text = pro.ProductId.ToString();
                txtUnitPrice.Text = pro.UnitPrice.ToString();
            }
        }

        private void frmAddDetail_Load(object sender, EventArgs e)
        {
            LoadProducts();
            if (AddOrUpdate == false)
            {
                btnAddOrUpdate.Text = "Add";
                cboProduct.SelectedIndex = 0;
                numDiscount.Value = 0;
                numQuantity.Value = 1;
            }
            else
            {
                btnAddOrUpdate.Text = "Update";
                cboProduct.Visible= false;
                lbProduct.Visible = false;
                //cboProduct.Text = ProductName;
                numDiscount.Value = (decimal)discount;
                numQuantity.Value = quantity;
                txtProductID.Text = productID.ToString();
                txtUnitPrice.Text = price.ToString();
            }
        }

        private void LoadProducts()
        {
            var products = ProductRepository.GetProducts();
            foreach (Product pro in products)
            {
                cboProduct.Items.Add(pro.ProductName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                productID = int.Parse(txtProductID.Text);
                quantity = int.Parse(numQuantity.Text);
                discount = double.Parse(numDiscount.Text);
                price = decimal.Parse(txtUnitPrice.Text);
                productName = cboProduct.Text;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Duplicated Product ID");
                DialogResult = DialogResult.None;
            }
        }
    }
}
