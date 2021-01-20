    using Microsoft.AspNetCore.Mvc;
    using Order.Service.Models;
using Order.Service.Repositories;
using System.Collections.Generic;

namespace Order.Service.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<Models.Order>> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);

        }

        [HttpGet]
        public ActionResult<Models.Order> GetOne(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        public ActionResult<Models.Order> GetByDeliveryStatus(bool deliveryStatus)
        {
            var orders = _orderRepository.GetByDeliveryStatus(deliveryStatus);

            return Ok(orders);
        }

        [HttpPost]
        public ActionResult<Models.Order> CreateOrder(Models.Cart cart)
        {
            var createdOrder = _orderRepository.Create(cart);
            if (createdOrder != null)
            {
                return Ok(createdOrder);
            }
            else
                return BadRequest();
        }

        [HttpDelete]
        public ActionResult<int> DeleteOrder(int orderId)
        {
            var deletedorder = _orderRepository.Delete(orderId);
            if (deletedorder!=null)
            {
                return Ok(deletedorder.Id);
            }
            else
                return NotFound();

        }

        [HttpPut]
        public ActionResult<Models.Order> UpdateOrderDeliveryStatus(int id,Models.Order order)
        {
            if (order.Id != id)
                return BadRequest();
          
              var  updatedOrder = _orderRepository.UpdateOrder(order);           
            
            if (updatedOrder != null)
                return Ok(updatedOrder);
            else
                return NotFound();
        }

    }
}
