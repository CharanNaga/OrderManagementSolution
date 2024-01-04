﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240103111209_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal");

                    b.HasKey("OrderID");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            OrderID = new Guid("e923c687-5284-4817-b4d4-5cc8549fad7d"),
                            CustomerName = "John Doe",
                            OrderDate = new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderNumber = "ORD_2023_1",
                            TotalAmount = 66.5m
                        },
                        new
                        {
                            OrderID = new Guid("e5afff42-f610-42ae-bac3-02da92c1fcde"),
                            CustomerName = "Jane Smith",
                            OrderDate = new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderNumber = "ORD_2023_2",
                            TotalAmount = 225.8m
                        });
                });

            modelBuilder.Entity("Entities.OrderItem", b =>
                {
                    b.Property<Guid>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal");

                    b.HasKey("OrderItemID");

                    b.ToTable("OrderItems", (string)null);

                    b.HasData(
                        new
                        {
                            OrderItemID = new Guid("d20882df-7fca-4ee8-88bb-37d2fc75e63f"),
                            OrderID = new Guid("e923c687-5284-4817-b4d4-5cc8549fad7d"),
                            ProductName = "Product A",
                            Quantity = 2,
                            TotalPrice = 20.00m,
                            UnitPrice = 10.00m
                        },
                        new
                        {
                            OrderItemID = new Guid("2e27b6a4-469d-4d7f-8b8b-54af129675fd"),
                            OrderID = new Guid("e923c687-5284-4817-b4d4-5cc8549fad7d"),
                            ProductName = "Product B",
                            Quantity = 3,
                            TotalPrice = 46.50m,
                            UnitPrice = 15.50m
                        },
                        new
                        {
                            OrderItemID = new Guid("24d71ac2-0a9c-4914-9fd3-13bc25d42694"),
                            OrderID = new Guid("e5afff42-f610-42ae-bac3-02da92c1fcde"),
                            ProductName = "Product C",
                            Quantity = 7,
                            TotalPrice = 177.80m,
                            UnitPrice = 25.40m
                        },
                        new
                        {
                            OrderItemID = new Guid("ac90b8bc-349d-43fd-87a6-6a7ed8057697"),
                            OrderID = new Guid("e5afff42-f610-42ae-bac3-02da92c1fcde"),
                            ProductName = "Product D",
                            Quantity = 4,
                            TotalPrice = 48.00m,
                            UnitPrice = 12.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
