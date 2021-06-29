using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order newOrder)
        {
            OrderDAO.Instance.Add(newOrder);
        }

        public void DeleteOrder(Order order)
        {
            OrderDAO.Instance.Delete(order);
        }

        public Order GetOrderByID(int orderID)
        {
            return OrderDAO.Instance.GetOrderById(orderID);
        }

        public DataTable GetOrders()
        {
            return OrderDAO.Instance.GetAll();
        }

        public DataTable GetOrdersByDate(DateTime start, DateTime end)
        {
            return OrderDAO.Instance.GetOrdersByDate(start, end);
        }

        public DataTable GetOrdersByMember(Member member)
        {
            return OrderDAO.Instance.GetOrdersByMember(member);
        }

        public void UpdateOrder(Order newOrder)
        {
            OrderDAO.Instance.Update(newOrder);
        }
    }
}
