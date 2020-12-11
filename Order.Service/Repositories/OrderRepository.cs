using Microsoft.EntityFrameworkCore;
using Order.Service.Context;
using Order.Service.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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



        //public Models.Order Create(Models.Order order)
        //{
        //    try
        //    {
        //        _context.Orders.Add(order);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }

        //    return order;
        //}

        public Models.Order Create(Models.Viewmodels.OrderViewModel orderViewModel)
        {
            var newOrder = new Models.Order()
            {
                UserId = orderViewModel.UserId,
                OrderDate = DateTime.Now,
                PaymentId = orderViewModel.PaymentId,
                DeliveryId = orderViewModel.DeliveryMethodId,
                Deliverd = false,
                TotalPrice=200

            };

          

            //List<Models.OrderItem> orderItemList = new List<Models.OrderItem>();
            Models.OrderItem orderItem = null;

            try
            {
                using (var transcation = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    _context.Orders.Add(newOrder);
                    _context.SaveChanges();
                    // await _context.SaveChangesAsync();



                    foreach (var item in orderViewModel.ProductList)
                    {
                         orderItem = new Models.OrderItem()
                        {
                            OrderId = newOrder.Id,
                            ProductId = item.Id,
                            Quantity = item.Quantity
                        };
                        _context.OrderItems.Add(orderItem);
                        _context.SaveChanges();
                        // orderItemList.Add(orderItem);
                        //_context.OrderItems.AddRange(orderItem);
                        // await _context.SaveChangesAsync();

                    }

                }

            }

            catch (Exception e)
            {

                
                return null;
            }

            return newOrder;


        }

      
    }
}
