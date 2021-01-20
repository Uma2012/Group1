using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsService.Models
{
    public interface IProductRepository
    {
        public List<Product.Service.Models.Product> GetAll();
        public Product.Service.Models.Product GetById(int id);
        public Product.Service.Models.Product Create(Product.Service.Models.Product product);
        public Product.Service.Models.Product Delete(int productId);
        public bool Update(Product.Service.Models.ShoppingCart cart);
    }
}
