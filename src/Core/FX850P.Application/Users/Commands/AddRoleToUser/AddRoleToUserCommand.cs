using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;

namespace FX850P.Application.Users.Commands.AddRoleUser;

public class AddRoleToUserCommand : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;

    public string Role { get; set; } = default!;

}
