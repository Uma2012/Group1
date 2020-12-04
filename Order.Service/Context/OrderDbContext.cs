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
    }
}