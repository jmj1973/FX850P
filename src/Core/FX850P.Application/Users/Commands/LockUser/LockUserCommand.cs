using FX850P.Application.Users.Dtos;
using MediatR;

namespace FX850P.Application.Users.Commands.LockUser
{
    public class LockUserCommand : IRequest<UserDto>
    {
        public string Id { get; set; } = default!;
    }
}
