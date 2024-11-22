using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public static class DbIntializer
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Category { Id = 2, Name = "Clothing", Description = "Apparel and fashion items", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Category { Id = 3, Name = "Books", Description = "A wide selection of books", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );

        // Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Smartphone",
                Description = "Latest model with high-end specs",
                Price = 799.99m,
                ImageUrl = "/images/products/smartphone.jpg",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Laptop",
                Description = "Powerful laptop for work and play",
                Price = 1199.99m,
                ImageUrl = "/images/products/laptop.jpg",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Name = "T-Shirt",
                Description = "Comfortable cotton T-shirt",
                Price = 19.99m,
                ImageUrl = "/images/products/tshirt.jpg",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 2
            },
            new Product
            {
                Id = 4,
                Name = "Jeans",
                Description = "Stylish and durable denim jeans",
                Price = 49.99m,
                ImageUrl = "/images/products/jeans.jpg",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 2
            },
            new Product
            {
                Id = 5,
                Name = "The Great Gatsby",
                Description = "A classic novel by F. Scott Fitzgerald",
                Price = 9.99m,
                ImageUrl = "/images/products/gatsby.jpg",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 3
            }
        );

        // Orders
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                OrderDate = DateTime.UtcNow,
                ShippedDate = DateTime.UtcNow.AddDays(2),
                Status = "Shipped",
                TotalAmount = 889.98m
            },
            new Order
            {
                Id = 2,
                OrderDate = DateTime.UtcNow,
                ShippedDate = null,
                Status = "Pending",
                TotalAmount = 69.98m
            }
        );
    }
}

