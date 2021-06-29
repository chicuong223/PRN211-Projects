using BusinessObjects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailsDAO
    {
        private static OrderDetailsDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailsDAO() { }
        public static OrderDetailsDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailsDAO();
                    }
                    return instance;
                }
            }
        }

        public DataTable GetOrderDetailsByOrder(int orderID)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                SqlConnection cnn = (SqlConnection)context.Database.GetDbConnection();
                string SQL = "SELECT Product.ProductId, Product.ProductName, OrderDetail.UnitPrice, OrderDetail.Quantity, OrderDetail.Discount, (OrderDetail.UnitPrice * (100 - OrderDetail.Discount)/100) as Subtotal FROM OrderDetail INNER JOIN Product ON OrderDetail.ProductId = Product.ProductId WHERE OrderDetail.OrderId = @OrderId";
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                cmd.Parameters.AddWithValue("@OrderId", orderID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddOrderDetail(OrderDetail detail)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.OrderDetails.Add(detail);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoveAllByOrder(Order order)
        {
            bool result = false;
            try
            {
                using FstoreContext context = new FstoreContext();
                SqlConnection cnn = (SqlConnection)context.Database.GetDbConnection();
                if(cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string SQL = "DELETE FROM OrderDetail WHERE OrderId = @OrderId";
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@OrderId", order.OrderId);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
