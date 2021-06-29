using BusinessObjects;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
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
    public partial class frmProducts : Form
    {
        private IProductRepository repository = new ProductRepository();
        BindingSource source = null;
        public frmProducts()
        {
            InitializeComponent();
        }

        private void LoadProducts()
        {
            source = new BindingSource();
            source.DataSource = repository.GetProducts();
            dgvList.DataSource = null;
            dgvList.DataSource = source;
            dgvList.Columns["OrderDetails"].Visible = false;

        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            cboSearchType.SelectedIndex = 0;
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure ?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Product pro = (Product)dgvList.CurrentRow.DataBoundItem;
                    repository.DeleteProduct(pro);
                    MessageBox.Show("Product deleted!", "Delete Product");
                    dgvList.Rows.Remove(dgvList.CurrentRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSearch.Text = cboSearchType.Text;
        }

        private void Search()
        {
            try
            {
                if (cboSearchType.SelectedIndex == 0)
                {
                    Product pro = repository.GetProductByID(int.Parse(txtSearch.Text));
                    source.DataSource = pro;
                }
                else
                {
                    IEnumerable<Product> lst = repository.GetProductsByName(txtSearch.Text);
                    if (lst.Count() < 1)
                    {
                        throw new Exception();
                    }
                    source.DataSource = lst;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not found!", "Search Product");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            var pro = dgvList.CurrentRow.DataBoundItem;
            frmProductDetails details = new frmProductDetails
            {
                Text = "Update Product",
                InsertOrUpdate = true,
                repo = repository,
                product = (Product)pro
            };
            details.ShowDialog();
            if (details.DialogResult == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
