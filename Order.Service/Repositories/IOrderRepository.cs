using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Repositories
{
    public interface IOrderRepository
    {
        public Models.Order CreateOrder(Models.Order order);
        public bool DeleteOrder(int id);
        public Models.Order GetOrderById(int orderId);
        //public Models.Order UpdateOrder(Models.Order order);
    }
}
