using EshopApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      
      modelBuilder.Entity<Product>()
          .Property(p => p.Name)
          .IsRequired()
          .HasMaxLength(100);
      
      modelBuilder.Entity<Product>()
          .Property(p => p.ImageUrl)
          .IsRequired()
          .HasMaxLength(150);
      
      modelBuilder.Entity<Product>()
          .Property(p => p.Description)
          .HasMaxLength(1000);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.LogTo(result => System.Diagnostics.Trace.WriteLine(result), Microsoft.Extensions.Logging.LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();

        optionsBuilder.UseSeeding((context, _) =>
        {
            var products = context.Set<Product>();
            
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartphone 1", ImageUrl = "https://example.com/smartphone1.jpg",
                Price = 499.99m, Description = "Latest model smartphone", QuantityInStock = 50
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Laptop 1", ImageUrl = "https://example.com/laptop1.jpg", Price = 899.99m,
                Description = "Powerful laptop with great performance", QuantityInStock = 30
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Tablet 1", ImageUrl = "https://example.com/tablet1.jpg", Price = 299.99m,
                Description = "High resolution tablet", QuantityInStock = 40
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartwatch 1", ImageUrl = "https://example.com/smartwatch1.jpg",
                Price = 199.99m, Description = "Wearable smartwatch with fitness tracking", QuantityInStock = 60
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Headphones 1", ImageUrl = "https://example.com/headphones1.jpg",
                Price = 79.99m, Description = "Noise-cancelling headphones", QuantityInStock = 100
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Bluetooth Speaker 1", ImageUrl = "https://example.com/speaker1.jpg",
                Price = 59.99m, Description = "Portable Bluetooth speaker", QuantityInStock = 75
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartphone 2", ImageUrl = "https://example.com/smartphone2.jpg",
                Price = 499.99m, Description = "High-end smartphone with amazing features", QuantityInStock = 50
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Laptop 2", ImageUrl = "https://example.com/laptop2.jpg", Price = 999.99m,
                Description = "Laptop with ultra-fast processor", QuantityInStock = 20
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Tablet 2", ImageUrl = "https://example.com/tablet2.jpg", Price = 350.99m,
                Description = "Premium tablet with great display", QuantityInStock = 60
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartwatch 2", ImageUrl = "https://example.com/smartwatch2.jpg",
                Price = 249.99m, Description = "Smartwatch with heart-rate monitor", QuantityInStock = 40
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Headphones 2", ImageUrl = "https://example.com/headphones2.jpg",
                Price = 129.99m, Description = "Over-ear headphones with deep bass", QuantityInStock = 80
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Bluetooth Speaker 2", ImageUrl = "https://example.com/speaker2.jpg",
                Price = 69.99m, Description = "Compact Bluetooth speaker with high quality sound", QuantityInStock = 90
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartphone 3", ImageUrl = "https://example.com/smartphone3.jpg",
                Price = 699.99m, Description = "Mid-range smartphone with great battery", QuantityInStock = 40
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Laptop 3", ImageUrl = "https://example.com/laptop3.jpg", Price = 1299.99m,
                Description = "Laptop with 16GB RAM and 512GB SSD", QuantityInStock = 15
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Tablet 3", ImageUrl = "https://example.com/tablet3.jpg", Price = 399.99m,
                Description = "Tablet with excellent performance and display", QuantityInStock = 55
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartwatch 3", ImageUrl = "https://example.com/smartwatch3.jpg",
                Price = 299.99m, Description = "Advanced smartwatch with GPS", QuantityInStock = 45
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Headphones 3", ImageUrl = "https://example.com/headphones3.jpg",
                Price = 199.99m, Description = "Wireless over-ear headphones", QuantityInStock = 70
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Bluetooth Speaker 3", ImageUrl = "https://example.com/speaker3.jpg",
                Price = 79.99m, Description = "Waterproof Bluetooth speaker", QuantityInStock = 80
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartphone 4", ImageUrl = "https://example.com/smartphone4.jpg",
                Price = 549.99m, Description = "Affordable smartphone with great camera", QuantityInStock = 50
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Laptop 4", ImageUrl = "https://example.com/laptop4.jpg", Price = 899.99m,
                Description = "Laptop for students and professionals", QuantityInStock = 30
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Tablet 4", ImageUrl = "https://example.com/tablet4.jpg", Price = 349.99m,
                Description = "Tablet with large screen and fast processor", QuantityInStock = 60
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartwatch 4", ImageUrl = "https://example.com/smartwatch4.jpg",
                Price = 179.99m, Description = "Smartwatch with fitness tracker and sleep monitor", QuantityInStock = 50
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Headphones 4", ImageUrl = "https://example.com/headphones4.jpg",
                Price = 89.99m, Description = "Wireless headphones with deep sound", QuantityInStock = 90
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Bluetooth Speaker 4", ImageUrl = "https://example.com/speaker4.jpg",
                Price = 65.99m, Description = "Affordable Bluetooth speaker", QuantityInStock = 95
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartphone 5", ImageUrl = "https://example.com/smartphone5.jpg",
                Price = 399.99m, Description = "Budget-friendly smartphone", QuantityInStock = 100
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Laptop 5", ImageUrl = "https://example.com/laptop5.jpg", Price = 799.99m,
                Description = "Laptop with sleek design", QuantityInStock = 40
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Tablet 5", ImageUrl = "https://example.com/tablet5.jpg", Price = 299.99m,
                Description = "Compact tablet for everyday use", QuantityInStock = 70
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartwatch 5", ImageUrl = "https://example.com/smartwatch5.jpg",
                Price = 229.99m, Description = "Premium smartwatch with health tracking", QuantityInStock = 55
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Headphones 5", ImageUrl = "https://example.com/headphones5.jpg",
                Price = 109.99m, Description = "In-ear headphones with great sound quality", QuantityInStock = 85
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Bluetooth Speaker 5", ImageUrl = "https://example.com/speaker5.jpg",
                Price = 59.99m, Description = "Portable speaker with impressive bass", QuantityInStock = 100
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartphone 6", ImageUrl = "https://example.com/smartphone6.jpg",
                Price = 599.99m, Description = "Smartphone with large display", QuantityInStock = 50
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Laptop 6", ImageUrl = "https://example.com/laptop6.jpg", Price = 1100.99m,
                Description = "Laptop with 1TB storage", QuantityInStock = 25
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Tablet 6", ImageUrl = "https://example.com/tablet6.jpg", Price = 499.99m,
                Description = "Tablet with 4GB RAM", QuantityInStock = 50
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartwatch 6", ImageUrl = "https://example.com/smartwatch6.jpg",
                Price = 349.99m, Description = "Smartwatch with voice assistant", QuantityInStock = 40
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Headphones 6", ImageUrl = "https://example.com/headphones6.jpg",
                Price = 149.99m, Description = "Noise-cancelling headphones", QuantityInStock = 60
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Bluetooth Speaker 6", ImageUrl = "https://example.com/speaker6.jpg",
                Price = 75.99m, Description = "Portable Bluetooth speaker with high bass", QuantityInStock = 80
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartphone 7", ImageUrl = "https://example.com/smartphone7.jpg",
                Price = 649.99m, Description = "Smartphone with fast performance", QuantityInStock = 55
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Laptop 7", ImageUrl = "https://example.com/laptop7.jpg", Price = 1200.99m,
                Description = "Gaming laptop with high-end GPU", QuantityInStock = 10
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Tablet 7", ImageUrl = "https://example.com/tablet7.jpg", Price = 499.99m,
                Description = "Tablet for professionals", QuantityInStock = 45
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartwatch 7", ImageUrl = "https://example.com/smartwatch7.jpg",
                Price = 359.99m, Description = "Smartwatch with GPS and music control", QuantityInStock = 35
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Headphones 7", ImageUrl = "https://example.com/headphones7.jpg",
                Price = 169.99m, Description = "Wireless headphones with studio quality", QuantityInStock = 75
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Bluetooth Speaker 7", ImageUrl = "https://example.com/speaker7.jpg",
                Price = 89.99m, Description = "Outdoor Bluetooth speaker", QuantityInStock = 70
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartphone 8", ImageUrl = "https://example.com/smartphone8.jpg",
                Price = 499.99m, Description = "Affordable smartphone with large screen", QuantityInStock = 60
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Laptop 8", ImageUrl = "https://example.com/laptop8.jpg", Price = 1099.99m,
                Description = "Laptop with fast SSD", QuantityInStock = 20
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Tablet 8", ImageUrl = "https://example.com/tablet8.jpg", Price = 349.99m,
                Description = "Affordable tablet with great performance", QuantityInStock = 50
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Smartwatch 8", ImageUrl = "https://example.com/smartwatch8.jpg",
                Price = 229.99m, Description = "Smartwatch with sport mode", QuantityInStock = 40
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Headphones 8", ImageUrl = "https://example.com/headphones8.jpg",
                Price = 89.99m, Description = "In-ear headphones for sports", QuantityInStock = 90
            });
            context.Set<Product>().Add(new Product
            {
                Id = Guid.NewGuid(), Name = "Bluetooth Speaker 8", ImageUrl = "https://example.com/speaker8.jpg",
                Price = 49.99m, Description = "Compact Bluetooth speaker with great sound", QuantityInStock = 80
            });
            context.SaveChanges();
        });
    }
}
