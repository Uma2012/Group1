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
            var user = await _userManager.GetUserAsync(User);
            
            var order = new Order()
            {
                CartItems = cart.cartItems,
                //UserId = Guid.Parse(_userManager.GetUserId(User)),
                UserId = Guid.Parse(user.Id),
                TotalPrice = cart.TotalPrice,
                Deliverd = false,
                DeliveryMethodId = int.Parse(form["Shipping method"]),
                PaymentId = int.Parse(form["Payment method"]),
                Address= user.Street + user.City+ user.PostalCode

        };

            await _orderService.PostAsync(order, $"{_orderServiceRootUrl}/api/order/createorder");

            order.Street = user.Street;
            order.City = user.City;
            order.PostalCode = user.PostalCode;


            return View(order);

        }
    }
}
