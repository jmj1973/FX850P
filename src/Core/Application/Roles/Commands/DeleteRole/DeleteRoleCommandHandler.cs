using Application.Common.Dtos;
using Application.Exceptions;
using Application.Mediator.Contracts;
using Domain.Presistence.Interfaces;


namespace Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IApplicationRequestHandler<DeleteRoleCommand, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;

    public DeleteRoleCommandHandler(IRoleService roleService) => _roleService = roleService;

    public async Task<KeyValuePairDto<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken = default)
    {
        // Check if exist
        Domain.Entities.Identity.ApplicationRole? role = await _roleService.FindUniqueAsync(r => r.Id == request.Id, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(nameof(role), request.Id);
        }

        await _roleService.DeleteAsync(role);

        return role.ToDto();
    }
}
