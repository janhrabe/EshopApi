using EshopApi.Core.Interfaces;
using EshopApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Infrastructure.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class, IEntity
{
    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
       return await context.Set<T>().FindAsync([id], cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
       await context.Set<T>().AddAsync(entity, cancellationToken);
       await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    { 
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}