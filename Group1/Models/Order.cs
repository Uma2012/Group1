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
        public List<CartItem> ProductList { get; set; }
        public double TotalPrice { get; set; }
        public int PaymentId { get; set; }
        public int DeliveryId { get; set; }
        public bool Deliverd { get; set; }
    }
    public class CartItem
    {
        public static explicit operator ProductList(CartItem cartItem)
        {
            var CartItem = new CartItem()
            {
                Product = cartItem.Product,
                Quantity = cartItem.Quantity
            };

            return CartItem;
        }
    }
}
