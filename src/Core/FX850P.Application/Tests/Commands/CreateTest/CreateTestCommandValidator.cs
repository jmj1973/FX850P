//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using FluentValidation;

namespace FX850P.Application.Tests.Commands.CreateTest;

public class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
{
    public CreateTestCommandValidator()
    {
        /*
        RuleFor(u => u.Number)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(u => u.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        */
    }

}
