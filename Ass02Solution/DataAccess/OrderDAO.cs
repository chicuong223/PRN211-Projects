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
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public DataTable GetAll()
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                SqlConnection cnn = (SqlConnection)context.Database.GetDbConnection();
                string cmd = "SELECT * From [Order]";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd, cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(Order order)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Order order)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Orders.Update(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Order GetOrderById(int orderID)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                var order = (from ord in context.Orders
                             where ord.OrderId == orderID
                             select ord).Single();
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetOrdersByDate(DateTime start, DateTime end)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                SqlConnection cnn = (SqlConnection)context.Database.GetDbConnection();
                string SQL = "SELECT [Order].*, x.Total FROM\n"
                    + "(SELECT DISTINCT OrderId, SUM(UnitPrice * Quantity * (1 - Discount)) as Total\n"
                    + "FROM OrderDetail WHERE OrderDetail.OrderId IN (\n"
                    + "SELECT OrderId FROM [Order] WHERE OrderDate Between @StartDate AND @EndDate)\n"
                    + "GROUP BY OrderId) as x, [Order]\n"
                    + "WHERE [Order].OrderId = x.OrderId";
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@StartDate", start);
                cmd.Parameters.AddWithValue("@EndDate", end);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
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

        public DataTable GetOrdersByMember(Member member)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                SqlConnection cnn = (SqlConnection)context.Database.GetDbConnection();
                string SQL = "SELECT [Order].*, x.Total FROM\n"
                    + "(SELECT DISTINCT OrderId, SUM(UnitPrice * Quantity * (1 - Discount)) as Total\n"
                    + "FROM OrderDetail WHERE OrderDetail.OrderId IN (\n"
                    + "SELECT OrderId FROM [Order] WHERE MemberId = @MemberId)\n"
                    + "GROUP BY OrderId) as x, [Order]\n"
                    + "WHERE [Order].OrderId = x.OrderId";
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
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
    }
}
