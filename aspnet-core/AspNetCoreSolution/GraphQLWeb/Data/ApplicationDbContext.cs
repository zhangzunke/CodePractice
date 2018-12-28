using GraphQLWeb.GraphQlCollection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Item>().HasKey(p => p.BarCode);

            modelBuilder.Entity<Item>().HasData(new Item
            {
                BarCode = "123",
                Title = "Headphone",
                SellingPrice = 50
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                BarCode = "456",
                Title = "Keyboard",
                SellingPrice = 40
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                BarCode = "789",
                Title = "Monitor",
                SellingPrice = 100
            });

            modelBuilder.Entity<Customer>().HasKey(p => p.CustomerId);
            modelBuilder.Entity<Customer>().HasMany(p => p.Orders)
                .WithOne()
                .HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<Order>().HasKey(p => p.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
