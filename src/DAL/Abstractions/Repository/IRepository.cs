using System.Linq.Expressions;

namespace DAL.Abstractions.Repository;

public interface IRepository<TEntity> where TEntity: class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void AddAsync(TEntity entity);
    void AddRangeAsync(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}