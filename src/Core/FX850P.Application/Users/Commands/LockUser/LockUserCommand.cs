using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;

namespace FX850P.Application.Users.Commands.LockUser;

public class LockUserCommand : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
}
