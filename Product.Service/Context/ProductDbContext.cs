using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.Service.Models;


namespace Product.Service.Context
{
    public class ProductDbContext: DbContext
    {
       
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }

        public DbSet<Models.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.Product>(entity =>
            {
                entity.Property(x => x.Name).IsRequired();
                entity.Property(x => x.Price).IsRequired();
                entity.Property(x => x.Quantity).IsRequired();
                entity.Property(x => x.ImageUrl);
                entity.Property(x => x.Description).IsRequired();

            });
            builder.Entity<Models.Product>().HasData(
                new Models.Product() {Name="Test",Price=200,Quantity=15,Description="Description" }

                );
        }

        }
}