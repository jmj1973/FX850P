namespace FX850P.Blazor.ViewModels.UserViewModels;

public class UserViewModel
{
    public string Id { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public bool LockoutEnabled { get; set; }
    public string Role { get; set; } = default!;
}
