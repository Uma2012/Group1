﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Service.Context;

namespace Product.Service.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Product.Service.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            ImageUrl = "/Images/Frozen Cheesecake.jpg",
                            Name = "Frozen cheescake",
                            Price = 50.0,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description",
                            ImageUrl = "/Images/Pizza.jpg",
                            Name = "Frozen pizza",
                            Price = 75.0,
                            Quantity = 15
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description",
                            ImageUrl = "/Images/Images/Lasagna.jpg",
                            Name = "Frozen lasagna",
                            Price = 125.0,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description",
                            ImageUrl = "/Images/Salmon.jpg",
                            Name = "Frozen salmon",
                            Price = 280.0,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description",
                            ImageUrl = "/Images/Chicken Pad Thai.jpg",
                            Name = "Frozen phad thai",
                            Price = 75.0,
                            Quantity = 15
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
