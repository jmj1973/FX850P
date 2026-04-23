
using FX850P.Application.Common.Dtos;

namespace FX850P.Blazor.ViewModels.CommonViewModels;

public static class CommonMapper
{

    public static KeyValuePairViewModel<TType> ToViewModel<TType>(this KeyValuePairDto<TType> dto) =>
        new KeyValuePairViewModel<TType>
        {
            Id = dto.Id,
            Name = dto.Name
        };
}
