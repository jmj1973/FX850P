using Application.Exceptions;
using Application.Mediator.Contracts;
using Application.Users.Dtos;
using Domain.Entities.Identity;
using Domain.Persistence.Interfaces;

namespace Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IApplicationRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService) => _userService = userService;

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

        UserDto returnUser = user.ToDto();
        returnUser.Role = request.Role;

        return returnUser;
    }
}
