using System.Linq.Expressions;

namespace Domain.Presistence.Interfaces;

public interface ISpecification<TEntity>
{
    bool IsSatisfiedBy(TEntity candidate);

    Expression<Func<TEntity, bool>> Expression { get; }

    IQueryable<TEntity> Include(IQueryable<TEntity> set);
}
