using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Context
{
    public class OrderDbContext : DbContext
    {

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.Delivery> Deliveries { get; set; }
        public DbSet<Models.PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Models.Delivery>().HasData(
              new Models.Delivery() { Id = 1, Name = "Homedelivery", Price = 50 },
              new Models.Delivery() { Id = 2, Name = "Takeaway", Price = 0 }
          );
            builder.Entity<Models.PaymentMethod>().HasData(
             new Models.PaymentMethod() { Id = 1, Name = "Swish" },
             new Models.PaymentMethod() { Id = 2, Name = "Card" }
         );
        }
    }
}