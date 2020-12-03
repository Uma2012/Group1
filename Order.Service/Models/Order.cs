using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }

    }
}
