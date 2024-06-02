using MediatR;
using FX850P.Application.Users.Dtos;

namespace FX850P.Application.Users.Commands.AddRoleUser
{
    public class AddRoleToUserCommand : IRequest<UserDto>
    {
        public string Id { get; set; } = default!;

        public string Role { get; set; } = default!;

    }
}
