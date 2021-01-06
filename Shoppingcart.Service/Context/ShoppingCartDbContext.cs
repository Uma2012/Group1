using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppingcart.Service.Context
{
    public class ShoppingCartDbContext :DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options):base(options)
        {

        }
    }
}
