using Application.Common.Dtos;
using Application.Exceptions;
using Application.Mediator.Contracts;
using Domain.Entities.Identity;
using Domain.Presistence.Interfaces;

namespace Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommandHandler : IApplicationRequestHandler<UpdateRoleCommand, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;

    public UpdateRoleCommandHandler(IRoleService roleService) => _roleService = roleService;

    public async Task<KeyValuePairDto<string>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken = default)
    {
        // Validation
        var validator = new UpdateRoleCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Check if exist
        ApplicationRole? role = await _roleService.FindUniqueAsync(r => r.Id == request.RoleId, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(nameof(role), request.RoleId);
        }

        role = request.ToEntity(role);

        await _roleService.UpdateAsync(role, cancellationToken);

        return role.ToDto();
    }
}
