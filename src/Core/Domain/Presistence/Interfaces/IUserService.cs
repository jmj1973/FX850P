using System.Linq.Expressions;
using Domain.Common;
using Domain.Entities.Identity;
using Domain.Resources;

namespace Domain.Presistence.Interfaces;

public interface IUserService
{
    Task<QueryResult<ApplicationUser>> GetPagedListAsync(UserQuery query, CancellationToken cancellationToken);
    Task<ApplicationUser> FindUniqueAsync(Expression<Func<ApplicationUser, bool>> predicate);
    Task<ApplicationUser> FindUniqueAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken);
    Task<bool> ExistAsync(Expression<Func<ApplicationUser, bool>> predicate);
    Task<bool> ExistAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken);
    Task AddAsync(ApplicationUser entity, string password, string role);
    Task AddAsync(ApplicationUser entity, string password, string role, CancellationToken cancellationToken);
    Task UpdateAsync(ApplicationUser entity);
    Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken);
    Task<ServiceResult> UpdatePasswordAsync(ApplicationUser entity, string oldPassword, string newPassword);
    Task LockAsync(ApplicationUser entity);
    Task UnlockAsync(ApplicationUser entity);
    Task DeleteAsync(ApplicationUser entity);
    Task AddRoleToUser(ApplicationUser entity, string role);
    Task RemoveRoleFromUser(ApplicationUser entity, string role);
    Task<IList<string>> GetUserRoles(ApplicationUser entity);
}
