using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommandHandler : IApplicationRequestHandler<UpdateRoleCommand, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

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

        _mapper.Map(request, role);

        await _roleService.UpdateAsync(role, cancellationToken);

        return _mapper.Map<KeyValuePairDto<string>>(role);
    }
}
