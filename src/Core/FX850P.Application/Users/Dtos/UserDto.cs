using FX850P.Application.Common.Dtos;


namespace FX850P.Application.Users.Dtos;

public class UserDto : BaseDto<string>
{
    public string UserName { get; set; } = default!;
    public string Fullname { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public bool LockoutEnabled { get; set; }
    public string Role { get; set; } = default!;
}
