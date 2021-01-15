using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool Availability { get; set; } = true;
    }
}
