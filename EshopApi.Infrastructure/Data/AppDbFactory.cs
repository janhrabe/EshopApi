using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EshopApi.Infrastructure.Data;

public class AppDbFactory : IDesignTimeDbContextFactory<AppDbContext>, IDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        return CreateDbContext();
    }

    public AppDbContext CreateDbContext()
    {
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Eshop.ApiDb;Integrated Security=True;");
        
        return new AppDbContext(optionBuilder.Options);
    }
}