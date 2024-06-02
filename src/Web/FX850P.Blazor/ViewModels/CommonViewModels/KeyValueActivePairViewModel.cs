namespace FX850P.Blazor.ViewModels.CommonViewModels
{
    public class KeyValueActivePairViewModel<TType>
    {
        public TType Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool Active { get; set; }
    }
}
