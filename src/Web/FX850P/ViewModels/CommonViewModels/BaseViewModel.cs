namespace FX850P.ViewModels.CommonViewModels;

public abstract class BaseViewModel<TType>
{
    public TType Id { get; set; } = default!;
}
