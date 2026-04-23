using FX850P.Application.Exceptions;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Users.Commands.LockUser;

public class LockUserCommandHandler : IApplicationRequestHandler<LockUserCommand, UserDto>
{
    private readonly IUserService _userService;

    public LockUserCommandHandler(IUserService userService) => _userService = userService;

    public async Task<UserDto> Handle(LockUserCommand request, CancellationToken cancellationToken = default)
    {
        // Check if exist
        Domain.Entities.Identity.ApplicationUser? user = await _userService.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.Id);
        }

        await _userService.LockAsync(user);

        return user.ToDto();
    }
}
