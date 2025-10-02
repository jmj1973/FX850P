namespace FX850P.Application.Common.Dtos;

public class KeyValuePairDto<TType>
{
    public TType Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}
