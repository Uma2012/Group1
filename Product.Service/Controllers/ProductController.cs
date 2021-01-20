using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Service.Models;
using ProductsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
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

        [HttpGet]
        public ActionResult<Models.Product> GetOne(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Models.Product> CreateProduct(Models.Product product)
        {
            var createdProduct = _productRepository.Create(product);
            if (createdProduct == null)
            {
                return BadRequest();
            }

            return Ok(product);
        }

        [HttpDelete]
        public ActionResult<Models.Product> DeleteProduct(int productId)
        {
            var deletedProduct = _productRepository.Delete(productId);
            if (deletedProduct == null)
            {
                return NotFound();
            }
            return Ok(deletedProduct);
        }

        [HttpPut]
        public ActionResult UpdateQuantity(ShoppingCart cart)
        {
            var isProductQuantityUpdated = _productRepository.Update(cart);
            if (isProductQuantityUpdated)
                return Ok();
            else
            return BadRequest();
        }
    }
}
