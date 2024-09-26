using FX850P.Application.Common.Commands;
using FX850P.Application.Users.Dtos;
using MediatR;

namespace FX850P.Application.Users.Commands.CreateUser;

public class CreateUserCommand : BaseAuditCommand, IRequest<UserDto>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Role { get; set; } = default!;
}
