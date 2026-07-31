using Application.Exceptions;
using Application.Mediator.Contracts;
using Application.Users.Dtos;
using Domain.Persistence.Interfaces;

namespace Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IApplicationRequestHandler<DeleteUserCommand, UserDto>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService) => _userService = userService;

    public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken = default)
    {
        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        await _userService.DeleteAsync(user);

        return user.ToDto();
    }
}
