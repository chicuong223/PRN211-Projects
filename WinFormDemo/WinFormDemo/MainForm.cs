using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            txtPassword.PlaceholderText = "Enter password here";

            //Create product list
            List<dynamic> proList = new List<dynamic> {
                new {Id = 1,Name = "Caphe"},
                new {Id = 2, Name="Coca"}
            };
            lstProducts.DataSource = proList;
            lstProducts.DisplayMember = "Name";
            lstProducts.ValueMember = "Id";
            lstProducts.SelectedIndexChanged += LstProducts_SelectedIndexChanged;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtPassword.MaxLength = 20;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void LstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get ID
            //int Id = (int)lstProducts.SelectedValue;
            var ID = lstProducts.SelectedValue;
            this.Text = ID.GetType().ToString();
            //get the whole object
            dynamic pro = lstProducts.SelectedItem;
            //this.Text = $"ID = {pro.Id}, Name = {pro.Name}";
        }
    }
}
