using FX850P.Application.Users.Dtos;
using MediatR;

namespace FX850P.Application.Users.Commands.AddRoleUser;

public class AddRoleToUserCommand : IRequest<UserDto>
{
    public string Id { get; set; } = default!;

    public string Role { get; set; } = default!;

}
