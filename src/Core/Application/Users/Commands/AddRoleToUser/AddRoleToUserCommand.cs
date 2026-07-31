using Application.Mediator.Contracts;
using Application.Users.Dtos;

namespace Application.Users.Commands.AddRoleToUser;

public class AddRoleToUserCommand : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;

    public string Role { get; set; } = default!;

}
