using Application.Mediator.Contracts;
using Application.Users.Dtos;

namespace Application.Users.Commands.UnlockUser;

public class UnlockUserCommand : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
}
