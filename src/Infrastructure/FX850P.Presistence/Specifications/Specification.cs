using System.Linq.Expressions;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Presistence.Specifications;

public abstract class Specification<TType> : ISpecification<TType>
{
    public abstract Expression<Func<TType, bool>> Expression { get; }

    /// <summary>
    /// Holds the compiled expression so that it doesn't need to compile it everytime.
    /// </summary>
    private Func<TType, bool> _compiledFunc = default!;

    public virtual bool IsSatisfiedBy(TType candidate)
    {
        _compiledFunc = _compiledFunc ?? Expression.Compile();
        return _compiledFunc(candidate);
    }

    public virtual IQueryable<TType> Include(IQueryable<TType> set) => set;

    public static implicit operator Expression<Func<TType, bool>>(Specification<TType> specification) => specification.Expression;

    public static implicit operator Func<TType, bool>(Specification<TType> specification) => specification.IsSatisfiedBy;

    public override string ToString() => Expression.ToString();
}
