namespace FX850P.Application.Exceptions;

public class DeleteFailureException : Exception
{
    public DeleteFailureException()
    {
    }

    public DeleteFailureException(string message) : base(message)
    {
    }

    public DeleteFailureException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public DeleteFailureException(string name, object key, string message)
    : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
    {
    }
}
