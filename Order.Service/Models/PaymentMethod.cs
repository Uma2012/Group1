using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
    }
}
