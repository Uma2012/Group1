using Product.Service.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsService.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public List<Product.Service.Models.Product> GetAll()
        {
            var products = _context.Products.ToList();

            return products;
        }
    }
}
