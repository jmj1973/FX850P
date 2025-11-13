using FluentValidation;

namespace FX850P.Blazor.ViewModels.UserViewModels;

public class UpdatePasswordViewModelValidator : AbstractValidator<UpdatePasswordViewModel>
{
    public UpdatePasswordViewModelValidator()
    {
        RuleFor(u => u.OldPassword)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(u => u.NewPassword)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(6).WithMessage("{PropertyName} must exceed {ComparisonValue} characters.");

        RuleFor(u => u.ConfirmPassword)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(6).WithMessage("{PropertyName} must exceed {ComparisonValue} characters.");

        RuleFor(u => u.ConfirmPassword)
            .Equal(u => u.NewPassword).WithMessage("The new password and confirmation password do not match.");

    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        FluentValidation.Results.ValidationResult result = await ValidateAsync(ValidationContext<UpdatePasswordViewModel>.CreateWithOptions((UpdatePasswordViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
        {
            return Array.Empty<string>();
        }

        return result.Errors.Select(e => e.ErrorMessage);
    };

}
