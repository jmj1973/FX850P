
using Application.Common.Dtos;

namespace FX850P.ViewModels.CommonViewModels;

public static class CommonMapper
{

    public static KeyValuePairViewModel<TType> ToViewModel<TType>(this KeyValuePairDto<TType> dto) =>
        new KeyValuePairViewModel<TType>
        {
            Id = dto.Id,
            Name = dto.Name
        };
}
