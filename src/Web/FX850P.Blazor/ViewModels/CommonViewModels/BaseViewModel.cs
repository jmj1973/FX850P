namespace FX850P.Blazor.ViewModels.CommonViewModels;

public abstract class BaseViewModel<TType>
{
    public TType Id { get; set; } = default!;
}
