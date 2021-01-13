
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
        private readonly string _cartName;
        private readonly ProductServiceHandler _productServiceHandler;
        private readonly string _apiRootUrl;


        public ShoppingcartController(IConfiguration config, ProductServiceHandler productServiceHandler)
        {
            this._cartName = config["CartSessionCookie:Name"];
            this._productServiceHandler = productServiceHandler;
            _apiRootUrl = config.GetValue(typeof(string), "ProductServiceURL").ToString();

        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productid)
        {
            //Read the session and get the content
            var currentCartItems = HttpContext.Session.Get<List<CartItem>>(_cartName);
            List<CartItem> cartItem = new List<CartItem>();

            //if session cookie is contaisn data, assign that to new listitem
            if (currentCartItems != null)
            {
                cartItem = currentCartItems;
            }

            //if the session cookie already contains the incoming productid , then increase the already eisting amount of that product by 1
            if (currentCartItems != null && currentCartItems.Any(x => x.Product.Id== productid))
            {
                int productindex = currentCartItems.FindIndex(x => x.Product.Id == productid);
                currentCartItems[productindex].Quantity += 1;
                cartItem = currentCartItems;
            }
            //if the session doest contain the incoming productid, then create a new item with amount =1
            else
            {
                // var product = _productRepository.GetProductById(productid);
                Models.Product product = await _productServiceHandler.GetOneAsyn<Models.Product>($"{_apiRootUrl}/api/product/GetOne?id=" + productid);

                CartItem newItem = new CartItem()
                {
                    Product = product,
                    Quantity = 1
                };
                cartItem.Add(newItem);
            }

            // set the session cookie with new listofItems
            HttpContext.Session.Set(_cartName, cartItem);

            return RedirectToAction("GetAllProducts", "Product");
        }

        [HttpGet]
        public IActionResult GetCartContent()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(_cartName);

            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCart.productlist = cart;

            //calculate total price only if the cart contains data
            if (cart != null)
            {
                shoppingCart.TotalPrice = (double)shoppingCart.productlist.Sum(x => x.Product.Price * x.Quantity);

                return View(shoppingCart);
            }

            else
            {
                return RedirectToAction("GetAllProducts", "Product");
            }
         }

        [HttpPost]
        public IActionResult DeleteAnItem(int id)
        {
            //get the session cookie content
            var currentCartItems = HttpContext.Session.Get<List<CartItem>>(_cartName);

            List<CartItem> cartItem = new List<CartItem>();

            //check if the cookie already contains the incoming productid, then remove the product from sessioncookie
            if (currentCartItems != null && currentCartItems.Any(x => x.Product.Id == id))
            {
                int productindex = currentCartItems.FindIndex(x => x.Product.Id == id);
                currentCartItems.RemoveAt(productindex);
                cartItem = currentCartItems;
            }

            //Update the sessionCookie
            HttpContext.Session.Set(_cartName, cartItem);

            return RedirectToAction("GetCartContent", "ShoppingCart");
        }

    }
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : System.Text.Json.JsonSerializer.Deserialize<T>(value);
        }
    }
}

