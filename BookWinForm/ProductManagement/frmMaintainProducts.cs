using System;
using System.Data;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class frmMaintainProducts : Form
    {
        public frmMaintainProducts()
        {
            InitializeComponent();
        }
        ProductData bn = new ProductData();
        DataTable dtProduct;
        private void btnNew_Click(object sender, EventArgs e)
        {
            int ID = 1;
            string Name = string.Empty;
            double Price = 0;
            int proQuantity = 0;
            if(dtProduct.Rows.Count > 0)
            {
                ID = int.Parse(dtProduct.Compute("MAX(ProductID)", "").ToString()) + 1;
            }
            Product pro = new Product
            {
                ProductID = ID,
                ProductName = Name,
                UnitPrice = Price,
                Quantity = proQuantity
            };
            frmProductDetails ProductDetails = new frmProductDetails(true, pro);
            DialogResult r = ProductDetails.ShowDialog();
            if(r == DialogResult.OK)
            {
                pro = ProductDetails.ProductAddOrEdit;
                dtProduct.Rows.Add(pro.ProductID, pro.ProductName, pro.UnitPrice, pro.Quantity);
            }
        }
        private void LoadData()
        {
            dtProduct = bn.GetProducts();
            dtProduct.PrimaryKey = new DataColumn[] { dtProduct.Columns["ProductID"] };
            dtProduct.Columns.Add("SubTotal", typeof(double), "Quantity * UnitPrice");
            bsProducts.DataSource = dtProduct;
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();

            txtID.DataBindings.Add("Text", bsProducts, "ProductID");
            txtName.DataBindings.Add("Text", bsProducts, "ProductName");
            txtPrice.DataBindings.Add("Text", bsProducts, "UnitPrice");
            txtQuantity.DataBindings.Add("Text", bsProducts, "Quantity");

            dgvProductsList.DataSource = bsProducts;
            bsProducts.Sort = "ProductID DESC";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            string Name = txtName.Text;
            double Price = float.Parse(txtPrice.Text);
            int proQuantity = int.Parse(txtQuantity.Text);
            Product pro = new Product
            {
                ProductID = ID,
                ProductName = Name,
                UnitPrice = Price,
                Quantity = proQuantity
            };
            frmProductDetails productDetails = new frmProductDetails(false, pro);
            DialogResult r = productDetails.ShowDialog();
            if(r == DialogResult.OK)
            {
                DataRow row = dtProduct.Rows.Find(pro.ProductID);
                row["ProductName"] = pro.ProductName;
                row["UnitPrice"] = pro.UnitPrice;
                row["Quantity"] = pro.Quantity;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            if (bn.DeleteProduct(ID))
            {
                DataRow row = dtProduct.Rows.Find(ID);
                dtProduct.Rows.Remove(row);
                MessageBox.Show("Delete Successfully!");
            }
            else
            {
                MessageBox.Show("Delete failed!");
            }
        }

        private void frmMaintainProducts_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
