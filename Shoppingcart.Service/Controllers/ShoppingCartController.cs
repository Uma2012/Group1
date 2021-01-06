using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppingcart.Service.Entity;
using Shoppingcart.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppingcart.Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
       [HttpPost]
       public async Task AddToCart([FromBody]ShoppingCart cart)
        {

        }

    }
}
