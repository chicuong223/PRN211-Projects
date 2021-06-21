using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class frmProductDetails : Form
    {
        public frmProductDetails()
        {
            InitializeComponent();
        }
        private bool AddOrEdit;
        public Product ProductAddOrEdit { get; set; }
        public frmProductDetails(bool flag, Product p) : this()
        {
            AddOrEdit = flag;
            ProductAddOrEdit = p;
            InitData();
        }

        public void InitData()
        {
            txtID.Text = ProductAddOrEdit.ProductID.ToString();
            txtName.Text = ProductAddOrEdit.ProductName;
            txtPrice.Text = ProductAddOrEdit.UnitPrice.ToString();
            txtQuantity.Text = ProductAddOrEdit.Quantity.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag;
            ProductAddOrEdit.ProductID = int.Parse(txtID.Text);
            ProductAddOrEdit.ProductName = txtName.Text;
            ProductAddOrEdit.UnitPrice = double.Parse(txtPrice.Text);
            ProductAddOrEdit.Quantity = int.Parse(txtQuantity.Text);
            ProductData proData = new ProductData();
            if(AddOrEdit == true)
            {
                flag = proData.AddProduct(ProductAddOrEdit);
            }
            else
            {
                flag = proData.UpdateProduct(ProductAddOrEdit);
            }
            if(flag == true)
            {
                MessageBox.Show("Save Successful!");
            }
            else
            {
                MessageBox.Show("Save failed!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
