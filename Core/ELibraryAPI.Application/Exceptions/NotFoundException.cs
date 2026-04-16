
namespace ELibraryAPI.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException():base("Invalid username or password")
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
