using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataSet dsMyStore = new DataSet();


        private void btnProduct_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = dsMyStore.Tables[0];
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = dsMyStore.Tables[1];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Server=DESKTOP-T5I6O1J; uid=chicuong;pwd=123;database=MyStore";
            string SQL = "SELECT ProductID, ProductName, UnitsInStock FROM Product; SELECT * FROM Category";
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQL, ConnectionString);
                dataAdapter.Fill(dsMyStore);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
