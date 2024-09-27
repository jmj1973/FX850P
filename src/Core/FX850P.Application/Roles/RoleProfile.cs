using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Roles.Commands.CreateRole;
using FX850P.Application.Roles.Commands.UpdateRole;
using FX850P.Application.Roles.Queries.GetRoleList;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Resources;

namespace FX850P.Application.Roles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<GetRoleListQuery, RoleQuery>();
        CreateMap<CreateRoleCommand, ApplicationRole>();
        CreateMap<UpdateRoleCommand, ApplicationRole>();
        CreateMap<ApplicationRole, KeyValuePairDto<string>>();
    }
}
