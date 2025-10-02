using FluentValidation;

namespace FX850P.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
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

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(6).WithMessage("{PropertyName} must exceed {ComparisonValue} characters.");

    }

}
