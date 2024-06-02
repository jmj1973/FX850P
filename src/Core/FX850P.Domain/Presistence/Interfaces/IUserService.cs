﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FX850P.Domain.Common;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Resources;

namespace FX850P.Domain.Presistence.Interfaces
{
    public interface IUserService
    {
        Task<QueryResult<ApplicationUser>> GetPagedListAsync(UserQuery query, CancellationToken cancellationToken);
        Task<ApplicationUser> FindUniqueAsync(Expression<Func<ApplicationUser, bool>> predicate);
        Task<ApplicationUser> FindUniqueAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken);
        Task<bool> ExistAsync(Expression<Func<ApplicationUser, bool>> predicate);
        Task<bool> ExistAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken);
        Task AddAsync(ApplicationUser entity, string password, string Role);
        Task AddAsync(ApplicationUser entity, string password, string Role, CancellationToken cancellationToken);
        Task UpdateAsync(ApplicationUser entity);
        Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken);
        Task<ServiceResult> UpdatePasswordAsync(ApplicationUser entity, string oldPassword, string newPassword);
        Task LockAsync(ApplicationUser entity);
        Task UnlockAsync(ApplicationUser entity);
        Task DeleteAsync(ApplicationUser entity);
        Task AddRoleToUser(ApplicationUser entity, string Role);
        Task RemoveRoleFromUser(ApplicationUser entity, string Role);
        Task<IList<string>> GetUserRoles(ApplicationUser entity);
    }
}
