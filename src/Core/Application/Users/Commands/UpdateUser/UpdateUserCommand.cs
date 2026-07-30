using Application.Common.Commands;
using Application.Mediator.Contracts;
using Application.Users.Dtos;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : BaseAuditCommand, IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Role { get; set; } = default!;
}
