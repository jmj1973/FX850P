
using System.Collections.Generic;

namespace FX850P.Domain.Common
{
    public class QueryResult<TEntity>
    {
        public PageResult Page { get; set; } = default!;
        public IEnumerable<TEntity> PageItems { get; set; } = default(IEnumerable<TEntity>)!;
    }
}
