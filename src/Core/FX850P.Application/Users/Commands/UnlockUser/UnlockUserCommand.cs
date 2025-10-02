using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;

namespace FX850P.Application.Users.Commands.UnlockUser;

public class UnlockUserCommand : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
}
