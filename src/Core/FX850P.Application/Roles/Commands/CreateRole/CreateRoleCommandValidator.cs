using FluentValidation;


namespace FX850P.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator() => RuleFor(u => u.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
}
