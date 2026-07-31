using Application.Common.Dtos;
using Application.Exceptions;
using Application.Mediator.Contracts;
using Domain.Entities.Identity;
using Domain.Persistence.Interfaces;

namespace Application.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IApplicationRequestHandler<CreateRoleCommand, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService) => _roleService = roleService;

    public async Task<KeyValuePairDto<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken = default)
    {
        // Validate
        var validator = new CreateRoleCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        //Check if exist
        bool existingUser = await _roleService.ExistAsync(r => r.Name != null && r.Name.ToUpper() == request.Name.ToUpper(), cancellationToken);

        if (existingUser)
        {
            throw new DuplicateException($"Role '{request.Name}' already exists.");
        }

        // Add User
        var role = new ApplicationRole
        {
            Name = request.Name
        };

        await _roleService.AddAsync(role, cancellationToken);

        return role.ToDto();
    }
}
