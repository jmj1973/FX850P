using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FX850P.Domain.Common;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Resources;

namespace FX850P.Domain.Presistence.Interfaces
{
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
}
