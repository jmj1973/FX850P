using Application.Common.Commands;
using Application.Mediator.Contracts;
using Application.Users.Dtos;


namespace Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : BaseAuditCommand, IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
}
