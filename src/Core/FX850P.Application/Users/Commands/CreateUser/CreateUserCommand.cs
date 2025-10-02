using FX850P.Application.Common.Commands;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;

namespace FX850P.Application.Users.Commands.CreateUser;

public class CreateUserCommand : BaseAuditCommand, IApplicationRequest<UserDto>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Role { get; set; } = default!;
}
