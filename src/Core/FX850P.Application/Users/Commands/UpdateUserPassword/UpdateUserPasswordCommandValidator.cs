using FluentValidation;


namespace FX850P.Application.Users.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator()
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
}
