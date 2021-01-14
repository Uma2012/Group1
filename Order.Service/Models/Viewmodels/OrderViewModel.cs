using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Models.Viewmodels
{
    public class OrderViewModel
    {       
        public int Id { get; set; }
        public Guid UserId { get; set; }        
        public List<CartItem> ProductList { get; set; }
        public int PaymentId { get; set; }
        public int DeliveryMethodId { get; set; }
        public double Totalprice { get; set; }
    }
    public class CartItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
