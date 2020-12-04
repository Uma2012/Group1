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
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public int PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<Product> Products { get; set; }
        public DateTime Date { get; set; }
        public bool Deliverd { get; set; }
        public double TotalPrice { get; set; }

    }
}
