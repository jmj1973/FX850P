using FluentValidation;
using FluentValidation.Results;

namespace FX850P.Blazor.ViewModels.UserViewModels;

public class UserViewModelValidator : AbstractValidator<UserViewModel>
{
    public UserViewModelValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(u => u.UserName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(6).WithMessage("{PropertyName} must exceed {ComparisonValue} characters.");

    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        ValidationResult result = await ValidateAsync(ValidationContext<UserViewModel>.CreateWithOptions((UserViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(e => e.ErrorMessage);
    };

}
