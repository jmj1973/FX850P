using FX850P.ViewModels.CommonViewModels;

namespace FX850P.Contracts;

public interface IRoleLookupService
{
    Task<List<KeyValuePairViewModel<string>>> ListAsync();
}
