using Order.Service.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public Models.Order GetById(int id)
        {

            var order = _context.Orders.FirstOrDefault(x => x.Id == id);

            return order;
        }

        public List<Models.Order> GetByDeliveryStatus(bool deliveryStatus)
        {
            var orders = _context.Orders.Where(x => x.Deliverd == deliveryStatus).ToList();

            return orders;
        }

        public Models.Order Create(Models.Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }
    }
}
