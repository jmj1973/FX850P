namespace FX850P.Blazor.ViewModels.UserViewModels;

public class UpdatePasswordViewModel
{
    public string Id { get; set; } = default!;

    public string OldPassword { get; set; } = default!;

    public string NewPassword { get; set; } = default!;

    public string ConfirmPassword { get; set; } = default!;

}
