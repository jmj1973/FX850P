using System;
using System.Linq.Expressions;

namespace FX850P.Domain.Common
{
    public class ColumnFilter<TType>
    {
        public bool HasValue { get; set; }
        public Expression<Func<TType, bool>> Expression { get; set; } = default(Expression<Func<TType, bool>>)!;
    }
}
