
using System.Collections.Generic;

namespace FX850P.Application.Common.Responses
{
    public class BaseCommandResponse<TType>
    {
        public TType Id { get; set; } = default!;
        public bool Success { get; set; } = true;
        public string Message { get; set; } = default!;
        public List<string> Errors { get; set; } = default!;
    }
}
