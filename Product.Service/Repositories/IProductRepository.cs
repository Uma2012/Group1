using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsService.Models
{
    public interface IProductRepository
    {
        public List<Product.Service.Models.Product> GetAll();

    }
}
