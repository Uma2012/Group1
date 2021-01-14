using Group1.Web.Models;
using Group1.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Group1.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderServiceHandler _orderService;
        private readonly UserManager<CustomUser> _userManager;
        private readonly string _orderServiceRootUrl;
        public OrderController(OrderServiceHandler productServiceHandler, IConfiguration config, UserManager<CustomUser> userManager)
        {
            _orderService = productServiceHandler;
            this._userManager = userManager;
            _orderServiceRootUrl = config["OrderServiceURL"];

        }

        [Authorize]
        public async Task<ActionResult<Order>> CreateOrder([Bind("TotalPrice", "cartItems")] ShoppingCart cart, IFormCollection form)
        {
            var order = new Order()
            {
                CartItems = cart.cartItems,
                UserId = Guid.Parse(_userManager.GetUserId(User)),
                TotalPrice = cart.TotalPrice,
                Deliverd = false,
                DeliveryMethodId = int.Parse(form["Shipping method"]),
                PaymentId = int.Parse(form["Payment method"])
            };

            await _orderService.PostAsync(order, $"{_orderServiceRootUrl}/api/order/createorder");
            return View(order);

        }
    }
}
