using FX850P.Application.Users.Dtos;
using MediatR;

namespace FX850P.Application.Users.Commands.UnlockUser;

public class UnlockUserCommand : IRequest<UserDto>
{
    public string Id { get; set; } = default!;
}
