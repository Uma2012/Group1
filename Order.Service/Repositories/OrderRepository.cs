using Order.Service.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Order.Service.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;        

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public List<Models.Order> GetAll() 
        {
            var orders = _context.Orders.ToList();
            return orders;
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
            var orderItemLists = new List<Models.OrderItem>();


            //if delivery type Id=1 then add 50 to total price
            if (cart.DeliveryId == 1)
                cart.Totalprice = cart.Totalprice + 50;

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    newOrder = new Models.Order()
                    {
                        UserId = cart.UserId,
                        OrderDate = DateTime.Now,
                        PaymentId = cart.PaymentId,
                        DeliveryId = cart.DeliveryId,
                        Deliverd = false,
                        TotalPrice = cart.Totalprice,
                        Address = cart.Address
                    };

                    _context.Orders.Add(newOrder);
                    _context.SaveChanges();


                    foreach (var item in cart.CartItems)
                    {
                        //    if (item.Product.Quantity > item.Quantity)
                        //    {
                        orderItem = new Models.OrderItem()
                            {
                                OrderId = newOrder.Id,
                                ProductId = item.Product.Id,
                                Quantity = item.Quantity
                            };
                            orderItemLists.Add(orderItem);
                           
                        //}
                        //_ = orderItem ?? throw new ArgumentException("orderItem shouldn't be null", nameof(orderItem));
                        
                       
                    }
                    _context.OrderItems.AddRange(orderItemLists);
                    _context.SaveChanges();
                    transaction.Complete();
                }
            }
            catch (Exception e)
            {

                return null;
            }

            return newOrder;
        }

        public Models.Order Delete(int orderId)
        {
            var order = GetOrderById(orderId);
            try
            {
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                }
                else
                    return null;
               
            }
            catch
            {
                return null;
            }
            return order;
        }

        public Models.Order UpdateOrder(Models.Order order)
        {
            var getOrder = GetOrderById(order.Id);
            try
            {
                if (getOrder != null)
                {
                    getOrder.Deliverd = order.Deliverd;
                    _context.Orders.Update(getOrder);
                    _context.SaveChanges();
                }
                else
                    return null;
            }
            catch(Exception e)
            {
                return null;
            }
            return getOrder;
        }

        //public List<Models.OrderItem> GetOrderItemsOfGivenOrderId(int orderId)
        //{
        //    var orderItems = _context.OrderItems.FirstOrDefault(x => x.OrderId == orderId);
        //    if (orderItems != null)
        //    {
        //        List<Models.OrderItem> orderItemsList = new List<Models.OrderItem>();
        //        orderItemsList = _context.OrderItems.Where(x => x.OrderId == orderId).ToList();
        //        return orderItemsList;
        //    }
        //    return null;
        //}
    }
}
