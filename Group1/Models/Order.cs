using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1.Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public double TotalPrice { get; set; }
        public int PaymentId { get; set; }
        public int DeliveryMethodId { get; set; }
        public bool Deliverd { get; set; }
    }
}
