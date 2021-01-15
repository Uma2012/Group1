using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public int PaymentId { get; set; }
        public int DeliveryMethodId { get; set; }
        public double Totalprice { get; set; }
        public string Address { get; set; }
    }
    public class CartItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
