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
        private readonly string _cartName;
        private readonly OrderServiceHandler _orderService;
        private readonly UserManager<CustomUser> _userManager;
        private readonly string _orderServiceRootUrl;
        public OrderController(OrderServiceHandler productServiceHandler, IConfiguration config, UserManager<CustomUser> userManager)
        {
            _orderService = productServiceHandler;
            this._userManager = userManager;
            _orderServiceRootUrl = config["OrderServiceURL"];
            this._cartName = config["CartSessionCookie:Name"];

        }

        [Authorize]
        public async Task<ActionResult<Order>> CreateOrder([Bind("TotalPrice", "cartItems")] ShoppingCart cart, IFormCollection form)
        {
            var user = await _userManager.GetUserAsync(User);

            var order = new Order()
            {
                CartItems = cart.cartItems,                
                UserId = Guid.Parse(user.Id),
                TotalPrice = cart.TotalPrice,
                Deliverd = false,
                DeliveryMethodId = int.Parse(form["deliveryMethod"]),
                PaymentId = int.Parse(form["paymentMethod"]),
                Address= user.Street + user.City+ user.PostalCode

        };

            await _orderService.PostAsync(order, $"{_orderServiceRootUrl}/api/order/createorder");

            order.Street = user.Street;
            order.City = user.City;
            order.PostalCode = user.PostalCode;
            order.FirstName = user.FirstName;
            order.LastName = user.LastName;

            //Clear the session cookies once the order is created
            if (HttpContext.Session.GetString(_cartName) != null)
                HttpContext.Session.Remove(_cartName);
            return View(order);

        }
    }
}
