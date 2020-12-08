using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Repositories
{
    public interface IOrderRepository
    {
        public Models.Order GetById(int id);
        public List<Models.Order> GetByDeliveryStatus(bool delivery);

        public Models.Order Create(Models.Order order);
    }
}
