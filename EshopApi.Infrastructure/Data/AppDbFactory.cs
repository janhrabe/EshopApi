using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace EshopApi.Infrastructure.Data;

public class AppDbFactory : IDesignTimeDbContextFactory<AppDbContext>, IDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        return CreateDbContext();
    }

    public AppDbContext CreateDbContext()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            
        var connectionString = configuration.GetConnectionString("EshopApiConnection");
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseSqlServer(connectionString);
        
        return new AppDbContext(optionBuilder.Options);
    }
}