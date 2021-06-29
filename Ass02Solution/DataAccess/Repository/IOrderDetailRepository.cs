using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        DataTable GetDetails(int orderID);
        void AddDetail(OrderDetail detail);
        bool RemoveByOrder(Order order);
    }
}
