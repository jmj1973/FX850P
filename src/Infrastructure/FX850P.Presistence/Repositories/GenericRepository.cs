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
    private readonly IDbContextFactory<ApplicationDBContext> _factory;

    public GenericRepository(IDbContextFactory<ApplicationDBContext> factory) => _factory = factory;

    public async Task<List<TEntity>> FindAllAsync()
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return await context.Set<TEntity>().AsNoTracking().ToListAsync();
    }
    public async Task<List<TEntity>> FindAllAsync(CancellationToken cancellationToken)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return await context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        await context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        await context.Set<TEntity>().AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        await context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return await context.Set<TEntity>().AsNoTracking().AnyAsync(predicate);
    }
    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return await context.Set<TEntity>().AsNoTracking().AnyAsync(predicate, cancellationToken);
    }

    public async Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return await context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
    }
    public async Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return await context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> FindUniqueAsync(Expression<Func<TEntity, bool>> predicate)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return await context.Set<TEntity>().Where(predicate).AsNoTracking().FirstOrDefaultAsync();
    }
    public async Task<TEntity?> FindUniqueAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        return await context.Set<TEntity>().Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
    }

    public void Remove(TEntity entity)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        context.Set<TEntity>().Remove(entity);
        context.SaveChanges();
    }
    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        context.Set<TEntity>().RemoveRange(entities);
        context.SaveChanges();
    }

    public async Task SaveAsync(TEntity entity)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        context.Entry<TEntity>(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task SaveAsync(TEntity entity, CancellationToken cancellationToken)
    {
        using ApplicationDBContext context = _factory.CreateDbContext();
        context.Entry<TEntity>(entity).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
    }

}
