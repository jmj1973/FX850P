using System.Linq.Expressions;

namespace Domain.Common;

public class ColumnFilter<TType>
{
    public bool HasValue { get; set; }
    public Expression<Func<TType, bool>> Expression { get; set; } = default!;
}
