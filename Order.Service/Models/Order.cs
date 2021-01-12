using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Models
{
    public class Order
    {    
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Deliverd { get; set; }
        public int PaymentId { get; set; }
        public int DeliveryId { get; set; }
        public double TotalPrice { get; set; }
        public Delivery Delivery { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string Address { get; set; }
        //public OrderItem OrderItem { get; set; }


    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //public Product Product { get; set; }
        public Order Order { get; set; }
       // public List<Order> OrderList { get; set; }

    }

   
}
