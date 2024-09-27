using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FX850P.Domain.Presistence.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> FindAllAsync();
    Task<List<TEntity>> FindAllAsync(CancellationToken cancellationToken);

    Task AddAsync(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    Task<TEntity?> FindUniqueAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> FindUniqueAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);

    Task SaveAsync(TEntity entity);
    Task SaveAsync(TEntity entity, CancellationToken cancellationToken);
}
