using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Models.Viewmodels
{
    public class OrderViewModel
    {
       // public int OrderId { get; set; }
       // public int ProductId { get; set; }
        public int UserId { get; set; }
        public List<Product> ProductList { get; set; }
        public int PaymentId { get; set; }
        public int DeliveryMethodId { get; set; }
    }
}
