using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Entities.Identity;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IApplicationRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken = default)
    {
        // Validate
        var validator = new CreateUserCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        //Check if exist
        bool existingUser = await _userService.ExistAsync(u => u.UserName != null && u.UserName.ToUpper() == request.UserName.ToUpper(), cancellationToken);

        if (existingUser)
        {
            throw new DuplicateException($"Username '{request.UserName}' already exists.");
        }

        bool existingEmail = await _userService.ExistAsync(u => u.Email != null && u.Email.ToUpper() == request.Email.ToUpper(), cancellationToken);

        if (existingEmail)
        {
            throw new DuplicateException($"Email '{request.Email}' already exists.");
        }

        // Add User
        var user = new ApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            EmailConfirmed = true
        };

        await _userService.AddAsync(user, request.Password, request.Role, cancellationToken);

        UserDto returnUser = _mapper.Map<UserDto>(user);
        returnUser.Role = request.Role;

        return returnUser;
    }
}
