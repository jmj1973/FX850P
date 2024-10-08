using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;
using MediatR;

namespace FX850P.Application.Roles.Queries.GetRoleList;

public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, QueryResultDto<KeyValuePairDto<string>>>
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public GetRoleListQueryHandler(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    public async Task<QueryResultDto<KeyValuePairDto<string>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        RoleQuery roleQuery = _mapper.Map<RoleQuery>(request);
        Domain.Common.QueryResult<Domain.Entities.Identity.ApplicationRole> queryResult = await _roleService.GetPagedListAsync(roleQuery, cancellationToken);
        return _mapper.Map<QueryResultDto<KeyValuePairDto<string>>>(queryResult);
    }
}
