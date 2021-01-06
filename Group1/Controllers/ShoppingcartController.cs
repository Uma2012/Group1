
using Group1.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1.Web.Controllers
{
    public class ShoppingcartController : Controller
    {
        private readonly CartServiceHandler _cartServiceHandler;
        private readonly string _productServiceRootUrl;
        public ShoppingcartController(CartServiceHandler cartServiceHandler, IConfiguration config)
        {
            _cartServiceHandler = cartServiceHandler;
            _productServiceRootUrl = config.GetValue(typeof(string), "CartServiceURL").ToString();

        }
        [HttpPost]
        public IActionResult AddToCart(Models.Product product)
        {
            return View();
        }
    }
}
