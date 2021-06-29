using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_BookWinForm
{
    public partial class frmBookManagement : Form
    {
        public frmBookManagement()
        {
            InitializeComponent();
        }
        DataTable dtBook;
        BookManager bm = new BookManager();

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadBookList();
        }

        private void LoadBookList()
        {
            dtBook = bm.getBooks();
            txtID.DataBindings.Clear();
            txtTitle.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();

            txtID.DataBindings.Add("Text", dtBook, "BookID");
            txtTitle.DataBindings.Add("Text", dtBook, "BookTitle");
            txtPrice.DataBindings.Add("Text", dtBook, "BookPrice");
            txtQuantity.DataBindings.Add("Text", dtBook, "BookQuantity");

            dgvBookList.DataSource = dtBook;
            lbTotal.Text = "Total Quantity: " + dtBook.Compute("SUM(BookQuantity)", string.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book = new Book
            {
                BookID = int.Parse(txtID.Text),
                BookTitle = txtTitle.Text,
                BookPrice = float.Parse(txtPrice.Text),
                BookQuantity = int.Parse(txtQuantity.Text)
            };
            bool r = bm.AddBook(book);
            string s = r == true ? "Successful" : "Failed";
            MessageBox.Show("Add " + s);
            LoadBookList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Book book = new Book
            {
                BookID = int.Parse(txtID.Text),
                BookTitle = txtTitle.Text,
                BookPrice = float.Parse(txtPrice.Text),
                BookQuantity = int.Parse(txtQuantity.Text)
            };
            bool r = bm.UpdateBook(book);
            string s = r == true ? "Successful" : "Failed";
            MessageBox.Show("Update " + s);
            LoadBookList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            bool r = bm.DeleteBook(ID);
            string s = r == true ? "Successful" : "Failed";
            MessageBox.Show("Delete " + s);
            LoadBookList();
        }

        private void txtFindTitle_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtBook.DefaultView;
            string filter = "BookTitle LIKE '%" + txtFindTitle.Text + "%'";
            dv.RowFilter = filter;
            lbTotal.Text = "Total Quantity: " + dtBook.Compute("SUM(BookQuantity)", filter);
        }
    }
}
