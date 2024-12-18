using System;
using System.Linq;
using System.Linq.Expressions;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Presistence.Specifications;

public abstract class Specification<TType> : ISpecification<TType>
{
    public abstract Expression<Func<TType, bool>> Expression { get; }

    /// <summary>
    /// Holds the compiled expression so that it doesn't need to compile it everytime.
    /// </summary>
    Func<TType, bool> _compiledFunc = default!;

    public virtual bool IsSatisfiedBy(TType entity)
    {
        _compiledFunc = _compiledFunc ?? this.Expression.Compile();
        return _compiledFunc(entity);
    }

    public virtual IQueryable<TType> Include(IQueryable<TType> set) => set;

    public static implicit operator Expression<Func<TType, bool>>(Specification<TType> specification)
    {
        return specification.Expression;
    }

    public static implicit operator Func<TType, bool>(Specification<TType> specification)
    {
        return specification.IsSatisfiedBy;
    }

    public override string ToString() => Expression.ToString();
}
