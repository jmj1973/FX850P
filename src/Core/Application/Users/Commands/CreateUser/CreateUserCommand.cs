using Application.Common.Commands;
using Application.Mediator.Contracts;
using Application.Users.Dtos;

namespace Application.Users.Commands.CreateUser;

public class CreateUserCommand : BaseAuditCommand, IApplicationRequest<UserDto>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Role { get; set; } = default!;
}
