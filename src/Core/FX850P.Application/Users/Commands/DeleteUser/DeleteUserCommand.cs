using FX850P.Application.Common.Commands;
using FX850P.Application.Users.Dtos;
using MediatR;


namespace FX850P.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : BaseAuditCommand, IRequest<UserDto>
{
    public string Id { get; set; } = default!;
}
