using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IApplicationRequestHandler<CreateRoleCommand, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

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

        return _mapper.Map<KeyValuePairDto<string>>(role);
    }
}
