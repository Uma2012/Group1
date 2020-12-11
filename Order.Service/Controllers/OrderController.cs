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
        public ActionResult<Models.Order> GetOne(int id)
        {
            var order = _orderRepository.GetById(id);
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
        public ActionResult<Models.Order> CreateOrder(Models.Viewmodels.OrderViewModel orderViewModel)
        {
            var createdOrder = _orderRepository.Create(orderViewModel);
            if (createdOrder != null)
            {
                return Ok(createdOrder);
            }
            else
                return BadRequest();
        }

        //[HttpPost]
        //public ActionResult<Models.OrderItem> CreateOrder(Models.Order order)
        //{
        //    var createdOrder = _orderRepository.Create(order);
        //    if (createdOrder != null)
        //        return Ok(createdOrder);
        //    else
        //        return BadRequest();
        //}

    }
}
