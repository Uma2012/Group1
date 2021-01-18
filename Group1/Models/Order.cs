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
        public int DeliveryId { get; set; }
        public bool Deliverd { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
