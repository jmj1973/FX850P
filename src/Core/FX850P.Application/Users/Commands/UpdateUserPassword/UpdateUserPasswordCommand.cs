using FX850P.Application.Users.Dtos;
using MediatR;

namespace FX850P.Application.Users.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommand : IRequest<UserDto>
{
    public string Id { get; set; } = default!;
    public string OldPassword { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}
