using System.Linq.Expressions;
using Domain.Common;
using Domain.Entities.Identity;
using Domain.Resources;

namespace Domain.Persistence.Interfaces;

public interface IRoleService
{
    Task<QueryResult<ApplicationRole>> GetPagedListAsync(RoleQuery query, CancellationToken cancellationToken);
    Task<ApplicationRole> FindUniqueAsync(Expression<Func<ApplicationRole, bool>> predicate);
    Task<ApplicationRole> FindUniqueAsync(Expression<Func<ApplicationRole, bool>> predicate, CancellationToken cancellationToken);
    Task<bool> ExistAsync(Expression<Func<ApplicationRole, bool>> predicate);
    Task<bool> ExistAsync(Expression<Func<ApplicationRole, bool>> predicate, CancellationToken cancellationToken);
    Task AddAsync(ApplicationRole entity);
    Task AddAsync(ApplicationRole entity, CancellationToken cancellationToken);
    Task UpdateAsync(ApplicationRole entity);
    Task UpdateAsync(ApplicationRole entity, CancellationToken cancellationToken);
    Task DeleteAsync(ApplicationRole entity);
}
