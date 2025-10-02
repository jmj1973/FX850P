using FX850P.Application.Common.Commands;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Users.Dtos;


namespace FX850P.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : BaseAuditCommand, IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
}
