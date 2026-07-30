namespace Domain.Common;

public class QueryResult<TEntity>
{
    public PageResult Page { get; set; } = default!;
    public IEnumerable<TEntity> PageItems { get; set; } = default!;
}
