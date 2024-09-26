using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FX850P.Blazor.ViewModels.MathematicsViewModels;

public class P5010ViewModelValidator : AbstractValidator<P5010ViewModel>
{
    public P5010ViewModelValidator()
    {
        RuleFor(x => x.Base)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(1).WithMessage("{PropertyName} > 1");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<P5010ViewModel>.CreateWithOptions((P5010ViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
