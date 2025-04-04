using EshopApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    
    
}