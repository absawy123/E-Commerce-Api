using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 21, 0, 20, 4, 644, DateTimeKind.Utc).AddTicks(3720), "Devices and gadgets", "Electronics", new DateTime(2024, 11, 21, 0, 20, 4, 644, DateTimeKind.Utc).AddTicks(3975) },
                    { 2, new DateTime(2024, 11, 21, 0, 20, 4, 644, DateTimeKind.Utc).AddTicks(4398), "Apparel and fashion items", "Clothing", new DateTime(2024, 11, 21, 0, 20, 4, 644, DateTimeKind.Utc).AddTicks(4398) },
                    { 3, new DateTime(2024, 11, 21, 0, 20, 4, 644, DateTimeKind.Utc).AddTicks(4400), "A wide selection of books", "Books", new DateTime(2024, 11, 21, 0, 20, 4, 644, DateTimeKind.Utc).AddTicks(4400) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "ShippedDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(4426), new DateTime(2024, 11, 23, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(4668), "Shipped", 889.98m },
                    { 2, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(5518), null, "Pending", 69.98m }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(2529), "Latest model with high-end specs", "/images/products/smartphone.jpg", false, "Smartphone", 799.99m, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(2771) },
                    { 2, 1, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(3464), "Powerful laptop for work and play", "/images/products/laptop.jpg", false, "Laptop", 1199.99m, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(3465) },
                    { 3, 2, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(3467), "Comfortable cotton T-shirt", "/images/products/tshirt.jpg", false, "T-Shirt", 19.99m, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(3468) },
                    { 4, 2, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(3470), "Stylish and durable denim jeans", "/images/products/jeans.jpg", false, "Jeans", 49.99m, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(3470) },
                    { 5, 3, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(3472), "A classic novel by F. Scott Fitzgerald", "/images/products/gatsby.jpg", false, "The Great Gatsby", 9.99m, new DateTime(2024, 11, 21, 0, 20, 4, 645, DateTimeKind.Utc).AddTicks(3472) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
