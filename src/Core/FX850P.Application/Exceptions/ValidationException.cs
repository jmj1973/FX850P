using FluentValidation.Results;

namespace FX850P.Application.Exceptions;

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Failures { get; }

    public ValidationException(string message) : base(message) => Failures = new Dictionary<string, string[]>();

    public ValidationException(string message, Exception innerException) : base(message, innerException) => Failures = new Dictionary<string, string[]>();

    public ValidationException() : base("One or more validation failures have occurred.") => Failures = new Dictionary<string, string[]>();

    public ValidationException(IReadOnlyCollection<ValidationFailure> failures) : this()
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

}
