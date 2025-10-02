using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Roles.Queries.GetRoleDetails;

public class GetRoleDetailsQueryHandler : IApplicationRequestHandler<GetRoleDetailsQuery, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public GetRoleDetailsQueryHandler(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    public async Task<KeyValuePairDto<string>> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.Identity.ApplicationRole? role = await _roleService.FindUniqueAsync(r => r.Id == request.Id, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(nameof(role), request.Id);
        }

        return _mapper.Map<KeyValuePairDto<string>>(role);
    }
}
