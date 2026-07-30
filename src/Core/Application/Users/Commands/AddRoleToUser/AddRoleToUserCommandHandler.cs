using Application.Exceptions;
using Application.Mediator.Contracts;
using Application.Users.Commands.AddRoleUser;
using Application.Users.Dtos;
using Domain.Presistence.Interfaces;

namespace Application.Users.Commands.AddRoleToUser;

public class AddRoleToUserCommandHandler : IApplicationRequestHandler<AddRoleToUserCommand, UserDto>
{
    private readonly IUserService _userService;

    public AddRoleToUserCommandHandler(IUserService userService) => _userService = userService;

    public async Task<UserDto> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken = default)
    {
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        //Remove old roles
        IList<string> roles = await _userService.GetUserRoles(user);
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
