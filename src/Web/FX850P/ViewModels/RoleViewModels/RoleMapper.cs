using Application.Common.Dtos;
using Application.Roles.Commands.CreateRole;
using Application.Roles.Commands.UpdateRole;
using FX850P.ViewModels.CommonViewModels;

namespace FX850P.ViewModels.RoleViewModels;

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
