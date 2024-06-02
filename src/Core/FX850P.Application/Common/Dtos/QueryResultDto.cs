
using System.Collections.Generic;

namespace FX850P.Application.Common.Dtos
{
    public class QueryResultDto<TEntityDto>
    {
        public PageResultDto Page { get; set; } = default!;
        public IEnumerable<TEntityDto> PageItems { get; set; } = default!;
    }
}
