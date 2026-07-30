using Application.Mediator.Contracts;
using Application.Users.Dtos;

namespace Application.Users.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommand : IApplicationRequest<UserDto>
{
    public string Id { get; set; } = default!;
    public string OldPassword { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}
