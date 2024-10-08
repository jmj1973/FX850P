﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace FX850P.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public ValidationException() : base("One or more validation failures have occurred.") => Failures = new Dictionary<string, string[]>();

    public ValidationException(List<ValidationFailure> failures) : this()
    {
        IEnumerable<string> propertyNames = failures
            .Select(e => e.PropertyName)
            .Distinct();

        foreach (string? propertyName in propertyNames)
        {
            string[] propertyFailures = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            Failures.Add(propertyName, propertyFailures);
        }
    }

    public IDictionary<string, string[]> Failures { get; }
}
