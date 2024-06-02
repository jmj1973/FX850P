using FX850P.Blazor.ViewModels.CommonViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FX850P.Blazor.Contracts
{
    public interface IRoleLookupService
    {
        Task<List<KeyValuePairViewModel<string>>> ListAsync();
    }
}
