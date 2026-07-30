namespace Application.Common.Dtos;

public abstract class BaseDto<TType>
{
    public TType Id { get; set; } = default!;
}
