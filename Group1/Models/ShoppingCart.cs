using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1.Web.Models
{
    public class ShoppingCart
    {
        public List<CartItem> productlist { get; set; }
        public double TotalPrice { get; set; }
        public Guid Userid { get; set; }
    }
    public class CartItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
