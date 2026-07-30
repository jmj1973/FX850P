using Application.Mediator.Contracts;
using Application.Users.Dtos;

namespace Application.Users.Commands.LockUser;

public class LockUserCommand : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
}
