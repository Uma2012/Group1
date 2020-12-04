using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class ProductController : ControllerBase
    {
        IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<Models.Product> GetAll()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }
    }
}
