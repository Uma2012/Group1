using Microsoft.AspNetCore.Mvc;
using Order.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        { 
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public ActionResult<Models.Order> CreateOrder([FromBody]Models.Order order)
        {
            
            var createOrder = _orderRepository.CreateOrder(order);
            if (createOrder  != null)
                return Ok(createOrder);
            else
                return BadRequest();
        }

        [HttpDelete]
        public ActionResult<int> DeleteOrder(int id)
        {
            var IsDeleted = _orderRepository.DeleteOrder(id);
            if (IsDeleted)
                return Ok(id);
            else
                return NotFound(id);

        }

    }
}
