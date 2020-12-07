using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
