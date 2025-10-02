using FX850P.Application.Common.Commands;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;

namespace FX850P.Application.Users.Commands.UpdateUser;

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
