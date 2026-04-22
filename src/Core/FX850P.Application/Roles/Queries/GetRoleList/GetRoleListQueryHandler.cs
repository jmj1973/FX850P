using FX850P.Application.Common;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator.Contracts;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;

namespace FX850P.Application.Roles.Queries.GetRoleList;

public class GetRoleListQueryHandler : IApplicationRequestHandler<GetRoleListQuery, QueryResultDto<KeyValuePairDto<string>>>
{
    private readonly IRoleService _roleService;

    public GetRoleListQueryHandler(IRoleService roleService) => _roleService = roleService;

    public async Task<QueryResultDto<KeyValuePairDto<string>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken = default)
    {
        RoleQuery roleQuery = request.ToEntity();
        Domain.Common.QueryResult<Domain.Entities.Identity.ApplicationRole> queryResult = await _roleService.GetPagedListAsync(roleQuery, cancellationToken);
        return queryResult.ToDto(RoleMapper.ToDto);
    }
}
