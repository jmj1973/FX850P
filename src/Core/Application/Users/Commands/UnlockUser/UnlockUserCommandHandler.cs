using Application.Exceptions;
using Application.Mediator.Contracts;
using Application.Users.Dtos;
using Domain.Persistence.Interfaces;

namespace Application.Users.Commands.UnlockUser;

public class UnlockUserCommandHandler : IApplicationRequestHandler<UnlockUserCommand, UserDto>
{
    private readonly IUserService _userService;

    public UnlockUserCommandHandler(IUserService userService) => _userService = userService;

    public async Task<UserDto> Handle(UnlockUserCommand request, CancellationToken cancellationToken = default)
    {
        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        await _userService.UnlockAsync(user);

        return user.ToDto();
    }
}
