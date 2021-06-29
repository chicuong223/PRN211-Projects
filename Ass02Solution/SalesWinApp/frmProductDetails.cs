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
    public partial class frmProductDetails : Form
    {
        public IProductRepository repo { get; set; }
        public Product product { get; set; }
        public bool InsertOrUpdate { get; set; }    //false: insert, true: update
        public frmProductDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
               string.IsNullOrWhiteSpace(txtName.Text) ||
               string.IsNullOrWhiteSpace(txtCategoryID.Text) ||
               string.IsNullOrWhiteSpace(txtWeight.Text) ||
               string.IsNullOrWhiteSpace(txtPrice.Text) ||
               string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all fields");
                DialogResult = DialogResult.None;
                return;
            }
            try
            {
                var newProduct = new Product
                {
                    ProductId = int.Parse(txtID.Text),
                    ProductName = txtName.Text,
                    CategoryId = int.Parse(txtCategoryID.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInStock = int.Parse(txtStock.Text),
                    OrderDetails = product.OrderDetails
                };
                if(InsertOrUpdate == false)
                {
                    repo.InsertProduct(newProduct);
                }
                else
                {
                    repo.UpdateProduct(newProduct);
                }
                product = newProduct;
                MessageBox.Show((InsertOrUpdate == false ? "Insert " : "Update ") + "Successfully");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult = DialogResult.None;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProductDetails_Load(object sender, EventArgs e)
        {
            txtID.Enabled = !InsertOrUpdate;
            try
            {
                txtID.Text = product.ProductId.ToString();
                txtName.Text = product.ProductName;
                txtCategoryID.Text = product.CategoryId.ToString();
                txtWeight.Text = product.Weight;
                txtPrice.Text = product.UnitPrice.ToString();
                txtStock.Text = product.UnitsInStock.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product");
            }
        }
    }
}
