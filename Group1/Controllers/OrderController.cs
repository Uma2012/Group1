using Group1.Web.Models;
using Group1.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderServiceHandler _orderService;
        private readonly UserManager<CustomUser> _userManager;
        private readonly string _orderServiceRootUrl;
        public OrderController(OrderServiceHandler productServiceHandler, IConfiguration config,UserManager<CustomUser> userManager)
        {
            _orderService = productServiceHandler;
            this._userManager = userManager;
            _orderServiceRootUrl = config["OrderServiceURL"];

        }
        public async Task<ActionResult<Order>> CreateOrder(ShoppingCart cart)
        {          
            var order = new Order()
            {
                ProductList=cart.productlist,
                UserId = Guid.Parse(_userManager.GetUserId(User)),
                TotalPrice =cart.TotalPrice
            };

            await _orderService.PostAsync(order, $"{_orderServiceRootUrl}/api/order/createorder");
            return View(order);
        }
    }
}
