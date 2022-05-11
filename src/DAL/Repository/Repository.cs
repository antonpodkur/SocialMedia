using System.Linq.Expressions;
using DAL.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
{
    protected readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().Where(predicate);
    }

    public async void AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async void AddRangeAsync(IEnumerable<TEntity> entities)
    { 
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }
}