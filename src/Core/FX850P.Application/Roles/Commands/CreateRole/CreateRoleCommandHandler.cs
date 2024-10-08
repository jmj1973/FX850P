using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Exceptions;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;

namespace FX850P.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, KeyValuePairDto<string>>
{
    private readonly IRoleService _roleService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IRoleService roleService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _roleService = roleService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<KeyValuePairDto<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        // Validate
        var validator = new CreateRoleCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult.Errors);

        //Check if exist
        bool existingUser = await _roleService.ExistAsync(r => r.Name.ToUpper() == request.Name.ToUpper());

        if (existingUser)
        {
            throw new Exception($"Role '{request.Name}' already exists.");
        }

        // Add User
        var role = new ApplicationRole
        {
            Name = request.Name
        };

        await _roleService.AddAsync(role);

        return _mapper.Map<KeyValuePairDto<string>>(role);
    }
}
