using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace FX850P.Blazor.Common;

/// <summary>
/// A glue class to make it easy to define validation rules for single values using FluentValidation
/// You can reuse this class for all your fields, like for the credit card rules above.
/// </summary>
/// <typeparam name="T"></typeparam>
public class FluentValueValidator<T> : AbstractValidator<T>
{
    public FluentValueValidator(Action<IRuleBuilderInitial<T, T>> rule)
    {
        ArgumentNullException.ThrowIfNull(rule);
        rule(RuleFor(x => x));
    }

    private IEnumerable<string> ValidateValue(T arg)
    {
        FluentValidation.Results.ValidationResult result = Validate(arg);
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    }

    public Func<T, IEnumerable<string>> Validation => ValidateValue;
}
