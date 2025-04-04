namespace EshopApi.Core.Interfaces;

public interface IRepository<T> : IReadRepository<T> where T : class, IEntity
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
}