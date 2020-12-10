namespace Order.Service.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Order.Service.Repositories;

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
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
        public ActionResult<Models.Order> CreateOrder(Models.Order order)
        {
            var createdOrder = _orderRepository.Create(order);
            return Ok(createdOrder);
        }
    }
}
