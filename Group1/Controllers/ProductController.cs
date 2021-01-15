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
            _productServiceRootUrl = config["ProductServiceURL"];
            //_productServiceRootUrl = config.GetValue(typeof(string), "ProductServiceURL").ToString();


        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Product>>> GetAllProducts()
        {
            List<Models.Product> allProducts = await _productService.GetAllAsync<Models.Product>($"{_productServiceRootUrl}/api/product/GetAll");
            return View(allProducts);
        }

        [HttpGet("productid")]
        public async Task<ActionResult<Models.Product>> GetOneProduct(int productid)
        {
            var product = await _productService.GetOneAsyn<Models.Product>($"{_productServiceRootUrl}/api/product/Getone?id="+ productid);
            if (product.Quantity < 1)
                product.Availability = false;
            return View(product);
        }
    }
}
