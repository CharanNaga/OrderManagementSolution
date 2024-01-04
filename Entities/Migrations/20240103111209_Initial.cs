using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemID", "OrderID", "ProductName", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("24d71ac2-0a9c-4914-9fd3-13bc25d42694"), new Guid("e5afff42-f610-42ae-bac3-02da92c1fcde"), "Product C", 7, 177.80m, 25.40m },
                    { new Guid("2e27b6a4-469d-4d7f-8b8b-54af129675fd"), new Guid("e923c687-5284-4817-b4d4-5cc8549fad7d"), "Product B", 3, 46.50m, 15.50m },
                    { new Guid("ac90b8bc-349d-43fd-87a6-6a7ed8057697"), new Guid("e5afff42-f610-42ae-bac3-02da92c1fcde"), "Product D", 4, 48.00m, 12.00m },
                    { new Guid("d20882df-7fca-4ee8-88bb-37d2fc75e63f"), new Guid("e923c687-5284-4817-b4d4-5cc8549fad7d"), "Product A", 2, 20.00m, 10.00m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerName", "OrderDate", "OrderNumber", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("e5afff42-f610-42ae-bac3-02da92c1fcde"), "Jane Smith", new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD_2023_2", 225.8m },
                    { new Guid("e923c687-5284-4817-b4d4-5cc8549fad7d"), "John Doe", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD_2023_1", 66.5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
