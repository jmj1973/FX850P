using FX850P.Application.Common.Dtos;
using FX850P.Application.Roles.Commands.CreateRole;
using FX850P.Application.Roles.Commands.UpdateRole;
using FX850P.Blazor.ViewModels.CommonViewModels;

namespace FX850P.Blazor.ViewModels.RoleViewModels;

public static class RoleMapper
{
    public static CreateRoleCommand ToCreateCommand(this KeyValuePairViewModel<string> vm) =>
        new CreateRoleCommand
        {
            Name = vm.Name
        };

    public static UpdateRoleCommand ToUpdateCommand(this KeyValuePairViewModel<string> vm) =>
        new UpdateRoleCommand
        {
            RoleId = vm.Id,
            Name = vm.Name
        };


    public static KeyValuePairViewModel<string> ToViewModel(this KeyValuePairDto<string> dto) =>
        new KeyValuePairViewModel<string>
        {
            Id = dto.Id,
            Name = dto.Name
        };
}
