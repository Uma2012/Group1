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

        public Product.Service.Models.Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            return product;
        }

        public Product.Service.Models.Product Create(Product.Service.Models.Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }
    }
}
