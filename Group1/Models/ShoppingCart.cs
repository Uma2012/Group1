using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1.Web.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }       
        //public Product Product { get; set; }
    }
}
