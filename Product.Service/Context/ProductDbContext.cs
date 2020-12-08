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
                new Models.Product() 
                {
                    Id= 1,
                    Name="Frozen cheescake",
                    Price= 50,
                    Quantity= 10,
                    ImageUrl = @"/Images/Frozen Cheesecake.jpg",
                    Description ="Description" 
                },
                new Models.Product()
                {
                    Id = 2,
                    Name = "Frozen pizza",
                    Price = 75,
                    Quantity = 15,
                    ImageUrl = @"/Images/Pizza.jpg",
                    Description = "Description"
                },
                new Models.Product()
                {
                    Id = 3,
                    Name = "Frozen lasagna",
                    Price = 125,
                    Quantity = 20,
                    ImageUrl = @"/Images/Images/Lasagna.jpg",
                    Description = "Description"
                },
                new Models.Product()
                {
                    Id = 4,
                    Name = "Frozen salmon",
                    Price = 280,
                    Quantity = 10,
                    ImageUrl = @"/Images/Salmon.jpg",
                    Description = "Description"
                },
                new Models.Product()
                {
                    Id = 5,
                    Name = "Frozen phad thai",
                    Price = 75,
                    Quantity = 15,
                    ImageUrl = @"/Images/Chicken Pad Thai.jpg",
                    Description = "Description"
                }
                );
        }

        }
}