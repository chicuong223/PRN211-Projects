using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        DataTable GetOrders();
        void AddOrder(Order newOrder);
        void DeleteOrder(Order order);
        void UpdateOrder(Order newOrder);
        Order GetOrderByID(int orderID);
        DataTable GetOrdersByDate(DateTime start, DateTime end);
        DataTable GetOrdersByMember(Member member);
    }
}
