using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Core.Interfaces;

public interface IGenericRepository<T, in TKey> where T : Entity<TKey>
{
    T? Get(TKey id);
    Task<T?> GetAsync(TKey id);
    void Save(T entity);
    Task SaveAsync(T entity);
    void Update(T entity);
    void Delete(TKey id);
    IQueryable<T> Entities { get; }
}