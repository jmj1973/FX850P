using Application.Exceptions;
using Application.Mediator.Contracts;
using Application.Users.Dtos;
using Domain.Persistence.Interfaces;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IApplicationRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUserService _userService;

    public UpdateUserCommandHandler(IUserService userService) => _userService = userService;

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken = default)
    {
        // Validation
        var validator = new UpdateUserCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        user = request.ToEntity(user);

        await _userService.UpdateAsync(user, cancellationToken);

        //Remove old roles
        System.Collections.Generic.IList<string> roles = await _userService.GetUserRoles(user);
        foreach (string removeRole in roles)
        {
            await _userService.RemoveRoleFromUser(user, removeRole);
        }

        await _userService.AddRoleToUser(user, request.Role);

        UserDto returnUser = user.ToDto();
        returnUser.Role = request.Role;

        return returnUser;
    }
}
