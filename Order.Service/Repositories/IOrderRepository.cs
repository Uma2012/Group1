using System.Collections.Generic;

namespace Order.Service.Repositories
{
    public interface IOrderRepository
    {
        public Models.Order GetById(int id);
        public List<Models.Order> GetByDeliveryStatus(bool delivery);

        public Models.Order Create(Models.Order order);
    }
}
