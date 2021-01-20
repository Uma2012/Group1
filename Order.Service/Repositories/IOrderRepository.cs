using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Repositories
{
    public interface IOrderRepository
    {
        public List<Models.Order> GetAll();
        public Models.Order GetOrderById(int id);
        public List<Models.Order> GetByDeliveryStatus(bool delivery);       
        public Models.Order Create(Models.Cart cart);
        public Models.Order Delete(int orderId);
        public Models.Order UpdateOrder(Models.Order order);
        
    }
}
