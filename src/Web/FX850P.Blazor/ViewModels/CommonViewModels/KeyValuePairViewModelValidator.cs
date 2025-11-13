using FluentValidation;

namespace FX850P.Blazor.ViewModels.CommonViewModels;

public class KeyValuePairViewModelValidator<TType> : AbstractValidator<KeyValuePairViewModel<TType>>
{
    public KeyValuePairViewModelValidator() => RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .Length(1, 100);

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        FluentValidation.Results.ValidationResult result = await ValidateAsync(ValidationContext<KeyValuePairViewModel<TType>>.CreateWithOptions((KeyValuePairViewModel<TType>)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
        {
            return Array.Empty<string>();
        }

        return result.Errors.Select(e => e.ErrorMessage);
    };

}
