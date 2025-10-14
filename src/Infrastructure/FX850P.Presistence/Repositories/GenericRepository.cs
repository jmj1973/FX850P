using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FX850P.Domain.Presistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FX850P.Presistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDBContext _context;

    public GenericRepository(ApplicationDBContext context) => _context = context;

    public async Task<List<TEntity>> FindAllAsync() => await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    public async Task<List<TEntity>> FindAllAsync(CancellationToken cancellationToken) => await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);

    public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => await _context.Set<TEntity>().AddAsync(entity, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _context.Set<TEntity>().AddRangeAsync(entities);
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken) => await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().AsNoTracking().AnyAsync(predicate);
    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) => await _context.Set<TEntity>().AsNoTracking().AnyAsync(predicate, cancellationToken);

    public async Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
    public async Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) => await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync(cancellationToken);

    public async Task<TEntity?> FindUniqueAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().Where(predicate).AsNoTracking().FirstOrDefaultAsync();
    public async Task<TEntity?> FindUniqueAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) => await _context.Set<TEntity>().Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

    public void Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);
    public void RemoveRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

    public async Task SaveAsync(TEntity entity) => _context.Entry<TEntity>(entity).State = EntityState.Modified;

    public async Task SaveAsync(TEntity entity, CancellationToken cancellationToken) => _context.Entry<TEntity>(entity).State = EntityState.Modified;

}
