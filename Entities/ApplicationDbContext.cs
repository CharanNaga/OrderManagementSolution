using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Mapping Entities binded to Tables
            modelBuilder.Entity<Order>().ToTable(nameof(Orders));
            modelBuilder.Entity<OrderItem>().ToTable(nameof(OrderItems));

            //seeding data into Tables
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    OrderID = Guid.Parse("E923C687-5284-4817-B4D4-5CC8549FAD7D"),
                    OrderNumber = "ORD_2023_1",
                    CustomerName = "John Doe",
                    OrderDate = DateTime.Parse("2023-08-28"),
                    TotalAmount = 66.5m
                },
                new Order()
                {
                    OrderID = Guid.Parse("E5AFFF42-F610-42AE-BAC3-02DA92C1FCDE"),
                    OrderNumber = "ORD_2023_2",
                    CustomerName = "Jane Smith",
                    OrderDate = DateTime.Parse("2023-07-25"),
                    TotalAmount = 225.8m
                });

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderItemID = Guid.Parse("D20882DF-7FCA-4EE8-88BB-37D2FC75E63F"),
                    OrderID = Guid.Parse("E923C687-5284-4817-B4D4-5CC8549FAD7D"),
                    ProductName = "Product A",
                    Quantity = 2,
                    UnitPrice = 10.00m,
                    TotalPrice = 20.00m
                },
               new OrderItem
               {
                   OrderItemID = Guid.Parse("2E27B6A4-469D-4D7F-8B8B-54AF129675FD"),
                   OrderID = Guid.Parse("E923C687-5284-4817-B4D4-5CC8549FAD7D"),
                   ProductName = "Product B",
                   Quantity = 3,
                   UnitPrice = 15.50m,
                   TotalPrice = 46.50m
               },
               new OrderItem
               {
                   OrderItemID = Guid.Parse("24D71AC2-0A9C-4914-9FD3-13BC25D42694"),
                   OrderID = Guid.Parse("E5AFFF42-F610-42AE-BAC3-02DA92C1FCDE"),
                   ProductName = "Product C",
                   Quantity = 7,
                   UnitPrice = 25.40m,
                   TotalPrice = 177.80m
               },
               new OrderItem
               {
                   OrderItemID = Guid.Parse("AC90B8BC-349D-43FD-87A6-6A7ED8057697"),
                   OrderID = Guid.Parse("E5AFFF42-F610-42AE-BAC3-02DA92C1FCDE"),
                   ProductName = "Product D",
                   Quantity = 4,
                   UnitPrice = 12.00m,
                   TotalPrice = 48.00m
               });
        }
    }
}