using System.Linq.Expressions;
using FX850P.Domain.Common;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;
using FX850P.Presistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FX850P.Presistence.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RoleService(RoleManager<ApplicationRole> roleManager) => _roleManager = roleManager;

    public async Task<QueryResult<ApplicationRole>> GetPagedListAsync(RoleQuery query, CancellationToken cancellationToken)
    {
        var queryResult = new QueryResult<ApplicationRole>()
        {
            Page = new PageResult()
        };
        IQueryable<ApplicationRole> queryDb = _roleManager.Roles;

        var columnsOrder = new Dictionary<string, Expression<Func<ApplicationRole, object>>>
        {
            ["Id"] = x => x.Id,
            ["Name"] = x => x.Name,
        };

        var columnsFilter = new Dictionary<bool, Expression<Func<ApplicationRole, bool>>>
        {
            //[userQuery.Id.HasValue] = x => x.Id == movieQuery.Id,
            [!string.IsNullOrWhiteSpace(query.SearchString)] = x => x.Name.Contains(query.SearchString),
            //[movieQuery.GenreId.HasValue] = x => x.GenreId == movieQuery.GenreId,
            //[movieQuery.NumberInStock.HasValue] = x => x.NumberInStock == movieQuery.NumberInStock,
        };

        queryDb = queryDb.ApplyFiltering(columnsFilter);

        queryResult.Page.TotalItems = await queryDb.CountAsync(cancellationToken);
        queryResult.Page.PageSize = query.PageSize;
        queryResult.Page.Page = query.Page;

        queryDb = queryDb.ApplyOrdering(query, columnsOrder);
        queryDb = queryDb.ApplyPaging(query);

        queryResult.PageItems = await queryDb.AsNoTracking()
                                             .ToListAsync(cancellationToken);

        return queryResult;
    }

    public async Task<ApplicationRole> FindUniqueAsync(Expression<Func<ApplicationRole, bool>> predicate)
    {
        IQueryable<ApplicationRole> query = _roleManager.Roles;

        return await query.Where(predicate)
                          .FirstOrDefaultAsync();
    }
    public async Task<ApplicationRole> FindUniqueAsync(Expression<Func<ApplicationRole, bool>> predicate, CancellationToken cancellationToken)
    {
        IQueryable<ApplicationRole> query = _roleManager.Roles;

        return await query.Where(predicate)
                          .FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<bool> ExistAsync(Expression<Func<ApplicationRole, bool>> predicate)
    {
        IQueryable<ApplicationRole> query = _roleManager.Roles;

        return await query.AsNoTracking()
                          .AnyAsync(predicate);
    }

    public async Task<bool> ExistAsync(Expression<Func<ApplicationRole, bool>> predicate, CancellationToken cancellationToken)
    {
        IQueryable<ApplicationRole> query = _roleManager.Roles;

        return await query.AsNoTracking()
                          .AnyAsync(predicate, cancellationToken);
    }

    public async Task AddAsync(ApplicationRole entity)
    {
        IdentityResult result = await _roleManager.CreateAsync(entity);

        if (!result.Succeeded)
        {
            throw new Exception($"{result.Errors}");
        }
    }

    public async Task AddAsync(ApplicationRole entity, CancellationToken cancellationToken)
    {
        IdentityResult result = await _roleManager.CreateAsync(entity);

        if (!result.Succeeded)
        {
            throw new Exception($"{result.Errors}");
        }
    }

    public async Task UpdateAsync(ApplicationRole entity) => await _roleManager.UpdateAsync(entity);

    public async Task UpdateAsync(ApplicationRole entity, CancellationToken cancellationToken) => await _roleManager.UpdateAsync(entity);

    public async Task DeleteAsync(ApplicationRole entity) => await _roleManager.DeleteAsync(entity);

}
