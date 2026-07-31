using Application.Common.Dtos;
using Application.Exceptions;
using Application.Mediator.Contracts;
using Domain.Persistence.Interfaces;

namespace Application.Roles.Queries.GetRoleDetails;

public class GetRoleDetailsQueryHandler : IApplicationRequestHandler<GetRoleDetailsQuery, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;

    public GetRoleDetailsQueryHandler(IRoleService roleService) => _roleService = roleService;

    public async Task<KeyValuePairDto<string>> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken = default)
    {
        Domain.Entities.Identity.ApplicationRole? role = await _roleService.FindUniqueAsync(r => r.Id == request.Id, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(nameof(role), request.Id);
        }

        return role.ToDto();
    }
}
