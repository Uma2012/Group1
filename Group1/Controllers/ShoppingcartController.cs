
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1.Web.Controllers
{
    public class ShoppingcartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
