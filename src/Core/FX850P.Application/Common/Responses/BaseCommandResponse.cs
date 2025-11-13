using System.Collections.ObjectModel;

namespace FX850P.Application.Common.Responses;

public class BaseCommandResponse<TType>
{
    public TType Id { get; set; } = default!;
    public bool Success { get; set; } = true;
    public string Message { get; set; } = default!;
    public ReadOnlyCollection<string> Errors { get; set; } = default!;
}
