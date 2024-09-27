using AutoMapper;
using FX850P.Application.Roles.Commands.CreateRole;
using FX850P.Application.Roles.Commands.UpdateRole;
using FX850P.Blazor.ViewModels.CommonViewModels;

namespace FX850P.Blazor.ViewModels.RoleViewModels;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<KeyValuePairViewModel<string>, CreateRoleCommand>();
        CreateMap<KeyValuePairViewModel<string>, UpdateRoleCommand>();
    }
}
