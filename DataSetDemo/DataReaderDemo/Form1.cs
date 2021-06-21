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

namespace DataReaderDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create a list to store products
            List<dynamic> products = new List<dynamic>();
            string ConnectionString = "server=DESKTOP-T5I6O1J; database=MyStore;uid=chicuong;pwd=123";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("SELECT ProductName, UnitPrice FROM Product", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if(reader.HasRows == true)
            {
                while (reader.Read())
                {
                    products.Add(new
                    {
                        ProductName = reader.GetString("ProductName"),
                        UnitPrice = reader.GetDecimal("UnitPrice")
                    });
                }
                dgvData.DataSource = products;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
