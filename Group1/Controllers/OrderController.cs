﻿using Group1.Web.Models;
using Group1.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        [Authorize]
        public async Task<ActionResult<Order>> CreateOrder([Bind("TotalPrice", "productlist")] ShoppingCart cart)
        {
                var order = new Order()
                {
                    ProductList = cart.productlist,
                    UserId = Guid.Parse(_userManager.GetUserId(User)),
                    TotalPrice = cart.TotalPrice,
                    Deliverd=false,
                    //PaymentId=,
                    //DeliveryId=
                };
            string OrderBaseurl = "http://localhost:64571/api/order/";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(OrderBaseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PostAsync("CreateOrder", content);
            }
            return View(order);
        }
    }
}
