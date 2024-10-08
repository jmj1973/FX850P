using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FX850P.Domain.Common;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;
using FX850P.Presistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FX850P.Presistence.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager) => _userManager = userManager;

    public async Task<QueryResult<ApplicationUser>> GetPagedListAsync(UserQuery query, CancellationToken cancellationToken)
    {
        var queryResult = new QueryResult<ApplicationUser>()
        {
            Page = new PageResult()
        };
        IQueryable<ApplicationUser> queryDb = _userManager.Users;

        var columnsOrder = new Dictionary<string, Expression<Func<ApplicationUser, object>>>
        {
            ["Id"] = x => x.Id,
            ["Email"] = x => x.Email,
            ["PhoneNumber"] = x => x.PhoneNumber,
            ["LockoutEnabled"] = x => x.LockoutEnabled,
        };

        var columnsFilter = new Dictionary<bool, Expression<Func<ApplicationUser, bool>>>
        {
            //[userQuery.Id.HasValue] = x => x.Id == movieQuery.Id,
            [!String.IsNullOrWhiteSpace(query.SearchString)] = x => x.Email.Contains(query.SearchString) ||
                                                                    x.PhoneNumber.Contains(query.SearchString),
            //[movieQuery.GenreId.HasValue] = x => x.GenreId == movieQuery.GenreId,
            //[movieQuery.NumberInStock.HasValue] = x => x.NumberInStock == movieQuery.NumberInStock,
        };

        queryDb = queryDb.ApplyFiltering(query, columnsFilter);

        queryResult.Page.TotalItems = await queryDb.CountAsync(cancellationToken);
        queryResult.Page.PageSize = query.PageSize;
        queryResult.Page.Page = query.Page;

        queryDb = queryDb.ApplyOrdering(query, columnsOrder);
        queryDb = queryDb.ApplyPaging(query);

        queryResult.PageItems = await queryDb.AsNoTracking()
                                             .ToListAsync(cancellationToken);

        return queryResult;
    }

    public async Task<ApplicationUser> FindUniqueAsync(Expression<Func<ApplicationUser, bool>> predicate)
    {
        IQueryable<ApplicationUser> query = _userManager.Users;

        return await query.Where(predicate)
                          .FirstOrDefaultAsync();
    }
    public async Task<ApplicationUser> FindUniqueAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken)
    {
        IQueryable<ApplicationUser> query = _userManager.Users;

        return await query.Where(predicate)
                           .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> ExistAsync(Expression<Func<ApplicationUser, bool>> predicate)
    {
        IQueryable<ApplicationUser> query = _userManager.Users;

        return await query.AsNoTracking()
                          .AnyAsync(predicate);
    }

    public async Task<bool> ExistAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken)
    {
        IQueryable<ApplicationUser> query = _userManager.Users;

        return await query.AsNoTracking()
                          .AnyAsync(predicate, cancellationToken);
    }

    public async Task AddAsync(ApplicationUser entity, string password, string role)
    {
        IdentityResult result = await _userManager.CreateAsync(entity, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(entity, role);
        }
        else
        {
            throw new Exception($"{result.Errors}");
        }
    }

    public async Task AddAsync(ApplicationUser entity, string password, string role, CancellationToken cancellationToken)
    {
        IdentityResult result = await _userManager.CreateAsync(entity, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(entity, role);
        }
        else
        {
            throw new Exception($"{result.Errors}");
        }
    }

    public async Task UpdateAsync(ApplicationUser entity)
    {
        await _userManager.UpdateAsync(entity);
    }

    public async Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken)
    {
        await _userManager.UpdateAsync(entity);
    }

    public async Task<ServiceResult> UpdatePasswordAsync(ApplicationUser entity, string oldPassword, string newPassword)
    {
        IdentityResult identityResult = await _userManager.ChangePasswordAsync(entity, oldPassword, newPassword);

        var serviceResult = ServiceResult.SuccessResult();

        foreach (IdentityError error in identityResult.Errors)
        {
            serviceResult = ServiceResult.FailResult(error.Description);
        }

        return serviceResult;
    }

    public async Task LockAsync(ApplicationUser entity)
    {
        await _userManager.SetLockoutEnabledAsync(entity, true);
        await _userManager.SetLockoutEndDateAsync(entity, DateTime.MaxValue);
    }

    public async Task UnlockAsync(ApplicationUser entity)
    {
        await _userManager.SetLockoutEnabledAsync(entity, false);
        await _userManager.SetLockoutEndDateAsync(entity, DateTime.Now - TimeSpan.FromMinutes(1));
    }

    public async Task DeleteAsync(ApplicationUser entity)
    {
        await _userManager.DeleteAsync(entity);
    }

    public async Task AddRoleToUser(ApplicationUser entity, string Role)
    {
        await _userManager.AddToRoleAsync(entity, Role);
    }

    public async Task RemoveRoleFromUser(ApplicationUser entity, string Role)
    {
        await _userManager.RemoveFromRoleAsync(entity, Role);
    }

    public async Task<IList<string>> GetUserRoles(ApplicationUser entity)
    {
        return await _userManager.GetRolesAsync(entity);
    }

}
