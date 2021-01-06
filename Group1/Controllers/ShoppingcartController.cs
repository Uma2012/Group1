
using Group1.Web.Models;
using Group1.Web.Services;
using Microsoft.AspNetCore.Http;
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
        private readonly string _cartServiceRootUrl;
        private readonly string _cartSessionCookie;
        public ShoppingcartController(CartServiceHandler cartServiceHandler, IConfiguration config)
        {
            _cartServiceHandler = cartServiceHandler;
            _cartServiceRootUrl = config.GetValue(typeof(string), "CartServiceURL").ToString();
            this._cartSessionCookie = config["CartSessionCookie:Name"];
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            // Generate a unique id
            Guid guid = Guid.NewGuid();

            // Does session cookie exist? If not, bake one!
            if (HttpContext.Session.GetString(_cartSessionCookie) == null)
                HttpContext.Session.SetString(_cartSessionCookie, guid.ToString());

            ShoppingCart shoppingCart = new ShoppingCart()
            {
                CartId = Guid.Parse(HttpContext.Session.GetString(_cartSessionCookie)),
                ProductId = productId,
                Amount = 1
            };

            await _cartServiceHandler.PostAsync<ShoppingCart>(shoppingCart, $"{_cartServiceRootUrl}/api/shoppingcart/addtocart");
           
            return View();
        }
    }
}
