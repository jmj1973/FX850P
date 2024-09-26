using System.Collections.Generic;
using System.Threading.Tasks;
using FX850P.Blazor.ViewModels.CommonViewModels;

namespace FX850P.Blazor.Contracts;

public interface IRoleLookupService
{
    Task<List<KeyValuePairViewModel<string>>> ListAsync();
}
