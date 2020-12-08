using Group1.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group1.Web;


namespace Group1.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ProductServiceHandler _productService;
        private readonly string _productServiceRootUrl;
        public ProductController(ProductServiceHandler productServiceHandler, IConfiguration config)
        {
            _productService = productServiceHandler;
            _productServiceRootUrl = config.GetValue(typeof(string), "ProductServiceURL").ToString();

        }

        public async Task<ActionResult<List<Models.Product>>> GetAllProducts()
        {
            List<Models.Product> allProducts = await _productService.GetAllAsync<Models.Product>($"{_productServiceRootUrl}GetAll");
            return View(allProducts);
        }
    }
}
