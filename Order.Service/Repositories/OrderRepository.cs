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
        public Models.Order CreateOrder(Models.Order order)
        {
            if (order.ProductId != 0)
            {
                try
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    return order;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Models.Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        //public Models.Order UpdateOrder(Models.Order order)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
