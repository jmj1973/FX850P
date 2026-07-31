using Application.Common.Dtos;
using Application.Common;
using Application.Common.Dtos;
using Application.Mediator.Contracts;
using Domain.Resources;
using Domain.Persistence.Interfaces;

namespace Application.Roles.Queries.GetRoleList;

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
