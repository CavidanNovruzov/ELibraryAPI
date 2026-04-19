

namespace ELibraryAPI.Application.Responses;

public class Result
{
    public bool IsSuccess { get; init; }
    public string? Message { get; init; }
    public List<string>? Errors { get; init; } // Behavior-lardan gələn çoxlu xətalar üçün

    protected Result(bool success, string? message, List<string>? errors = null)
    {
        IsSuccess = success;
        Message = message;
        Errors = errors;
    }

    // Parametrsiz uğur (Sadəcə IsSuccess = true)
    public static Result Success() => new(true, null);

    // Mesajlı uğur (Artıq "Publisher deleted" yaza bilərsən)
    public static Result Success(string message) => new(true, message);

    // Tək mesajlı xəta
    public static Result Failure(string message) => new(false, message);

    // Çoxlu xətalar (Məsələn, Validation Behavior üçün)
    public static Result Failure(List<string> errors, string message = "Validation failed")
        => new(false, message, errors);
}
public class Result<T> : Result
{
    public T? Data { get; init; }

    private Result(T? data, bool success, string? message, List<string>? errors = null)
        : base(success, message, errors)
    {
        Data = data;
    }

    // Uğurlu halda data mütləqdir
    public static Result<T> Success(T data) => new(data, true, null);

    // Uğurlu halda həm data, həm mesaj
    public static Result<T> Success(T data, string message) => new(data, true, message);

    // Xəta halı (Inherit vasitəsilə base xətaları istifadə edir)
    public static new Result<T> Failure(string message) => new(default, false, message);

    public static new Result<T> Failure(List<string> errors, string message = "Error occurred")
        => new(default, false, message, errors);
}