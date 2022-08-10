using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class Repository<T, TKey> : IGenericRepository<T, TKey> where T : Entity<TKey>
{
    private readonly ApplicationContext _context;
    
    public Repository(ApplicationContext context)
    {
        _context = context;
    }

    public T? Get(TKey id)
    {
        return _context.Set<T>().FirstOrDefault(x => x.Id != null && x.Id.Equals(id));
    }

    public async Task<T?> GetAsync(TKey id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id != null && x.Id.Equals(id));
    }

    public void Save(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public async Task SaveAsync(T entity)
    {
       await _context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(TKey id)
    {
        var entities = _context.Set<T>();
        var entityToRemove = entities.FirstOrDefault(x => x.Id != null && x.Id.Equals(id));
        if(entityToRemove != null)
            entities.Remove(entityToRemove);
    }
    public IQueryable<T> Entities => _context.Set<T>().AsQueryable();

}