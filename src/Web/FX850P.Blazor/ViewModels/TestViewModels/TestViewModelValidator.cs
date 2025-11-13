//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using FluentValidation;
namespace FX850P.Blazor.ViewModels.TestViewModels;

public class TestViewModelValidator : AbstractValidator<TestViewModel>
{
    public TestViewModelValidator()
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

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        FluentValidation.Results.ValidationResult result = await ValidateAsync(ValidationContext<TestViewModel>.CreateWithOptions((TestViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
        {
            return Array.Empty<string>();
        }

        return result.Errors.Select(e => e.ErrorMessage);
    };

}
