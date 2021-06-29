using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddDetail(OrderDetail detail)
        {
            OrderDetailsDAO.Instance.AddOrderDetail(detail);
        }

        public DataTable GetDetails(int orderID)
        {
            return OrderDetailsDAO.Instance.GetOrderDetailsByOrder(orderID);
        }

        public bool RemoveByOrder(Order order)
        {
            return OrderDetailsDAO.Instance.RemoveAllByOrder(order);
        }
    }
}
