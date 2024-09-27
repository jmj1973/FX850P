
using System;

namespace FX850P.Application.Exceptions;

public class DeleteFailureException : ApplicationException
{
    public DeleteFailureException(string name, object key, string message)
        : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
    {
    }
}
