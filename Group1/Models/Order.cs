using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1.Web.Models
{
    public class Order
    {
        public Guid UserId { get; set; }
        public List<CartItem> ProductList { get; set; }
        public double TotalPrice { get; set; }
    }
}
