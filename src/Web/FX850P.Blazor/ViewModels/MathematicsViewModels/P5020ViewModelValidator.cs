using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FX850P.Blazor.ViewModels.MathematicsViewModels;

public class P5020ViewModelValidator : AbstractValidator<P5020ViewModel>
{
    public P5020ViewModelValidator()
    {
        RuleFor(x => x.A)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} >= 1");

        RuleFor(x => x.B)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} >= 1");

    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<P5020ViewModel>.CreateWithOptions((P5020ViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };

}
