using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CategoryManagement management = new CategoryManagement();
        private void LoadCategories()
        {
            var categories = management.GetCategories();
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            //Bind to text boxes
            txtID.DataBindings.Add("Text", categories, "CategoryID");
            txtName.DataBindings.Add("Text", categories, "CategoryName");
            //Bind to dgv
            dgvCategory.DataSource = categories;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new Category { CategoryName = txtName.Text };
                management.InsertCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Category");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new Category { CategoryID = int.Parse(txtID.Text), CategoryName = txtName.Text };
                management.UpdateCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Category");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var cateogory = new Category
                {
                    CategoryID = int.Parse(txtID.Text),
                    CategoryName = txtName.Text
                };
                management.DeleteCategory(cateogory);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Category");
            }
        }
    }
}
