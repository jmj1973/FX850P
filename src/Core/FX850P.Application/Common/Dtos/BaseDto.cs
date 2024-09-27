namespace FX850P.Application.Common.Dtos;

public abstract class BaseDto<TType>
{
    public TType Id { get; set; } = default!;
}
