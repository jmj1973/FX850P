using AutoMapper;
using FX850P.Application.Common.Dtos;

namespace FX850P.Blazor.ViewModels.CommonViewModels;

public class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<KeyValuePairDto<string>, KeyValuePairViewModel<string>>().ReverseMap();
    }
}
