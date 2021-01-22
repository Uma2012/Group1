using Group1.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Group1.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            string ADMIN_ID = Guid.NewGuid().ToString();           

            var hasher = new PasswordHasher<CustomUser>();
            modelBuilder.Entity<CustomUser>().HasData(new CustomUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                IsAdmin=true,
                PasswordHash = hasher.HashPassword(null, "Test123!"),
                SecurityStamp = string.Empty
            });            

            base.OnModelCreating(modelBuilder);           
        }
    }
}
