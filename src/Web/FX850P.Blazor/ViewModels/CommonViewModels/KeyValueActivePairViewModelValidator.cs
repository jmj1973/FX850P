﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FX850P.Blazor.ViewModels.CommonViewModels;

public class KeyValueActivePairViewModelValidator<TType> : AbstractValidator<KeyValueActivePairViewModel<TType>>
{
    public KeyValueActivePairViewModelValidator() => RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .Length(1, 100);

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        FluentValidation.Results.ValidationResult result = await ValidateAsync(ValidationContext<KeyValueActivePairViewModel<TType>>.CreateWithOptions((KeyValueActivePairViewModel<TType>)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };

}
