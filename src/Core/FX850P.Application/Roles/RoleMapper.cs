using FX850P.Application.Common.Dtos;
using FX850P.Application.Roles.Commands.CreateRole;
using FX850P.Application.Roles.Commands.UpdateRole;
using FX850P.Application.Roles.Queries.GetRoleList;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Resources;

namespace FX850P.Application.Roles;

public static class RoleMapper
{
    public static KeyValuePairDto<string> ToDto(this ApplicationRole role) => 
        new KeyValuePairDto<string>
        {
            Id = role.Id,
            Name = role.Name,
        };

    public static ApplicationRole ToEntity(this CreateRoleCommand command) =>
        new ApplicationRole
        {
            Name = command.Name,
        };

    public static ApplicationRole ToEntity(this UpdateRoleCommand command, ApplicationRole role)
    {
        role.Id = command.RoleId;
        role.Name = command.Name;
        return role;
    }

    public static RoleQuery ToEntity(this GetRoleListQuery query) =>
        new RoleQuery
        {
            SearchString = query.SearchString,
            SortBy = query.SortBy,
            IsSortAscending = query.IsSortAscending,
            Page = query.Page,
            PageSize = query.PageSize,
        };

}
