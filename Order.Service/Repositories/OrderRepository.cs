using Order.Service.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Service.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public Models.Order GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            return order;
        }

        public List<Models.Order> GetByDeliveryStatus(bool deliveryStatus)
        {
            var orders = _context.Orders.Where(x => x.Deliverd == deliveryStatus).ToList();
            return orders;
        }

        public Models.Order Create(Models.Cart cart)
        {
            Models.OrderItem orderItem = null;
            Models.Order newOrder = null;

            //if delivery type Id=1 then add 50 to total price
            if (cart.DeliveryMethodId == 1)
                cart.Totalprice = cart.Totalprice + 50;
            try
            {
                newOrder = new Models.Order()
                {
                    UserId = cart.UserId,
                    OrderDate = DateTime.Now,
                    PaymentId = cart.PaymentId,
                    DeliveryId = cart.DeliveryMethodId,
                    Deliverd = false,
                    TotalPrice = cart.Totalprice
                };

                _context.Orders.Add(newOrder);
                _context.SaveChanges();


                foreach (var item in cart.CartItems)
                {
                    orderItem = new Models.OrderItem()
                    {
                        OrderId = newOrder.Id,
                        ProductId = item.Product.Id,
                        Quantity = item.Quantity
                    };
                    _context.OrderItems.Add(orderItem);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return newOrder;
        }

        public bool Delete(int orderId)
        {
            var order = GetOrderById(orderId);
            try
            {
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                }
                var orderItems = GetOrderItemsOfGivenOrderId(orderId);
                if (orderItems != null)
                {
                    _context.OrderItems.RemoveRange(orderItems);
                    _context.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Models.OrderItem> GetOrderItemsOfGivenOrderId(int orderId)
        {
            var orderItems = _context.OrderItems.FirstOrDefault(x => x.OrderId == orderId);
            if (orderItems != null)
            {
                List<Models.OrderItem> orderItemsList = new List<Models.OrderItem>();
                orderItemsList = _context.OrderItems.Where(x => x.OrderId == orderId).ToList();
                return orderItemsList;
            }
            return null;
        }
    }
}
