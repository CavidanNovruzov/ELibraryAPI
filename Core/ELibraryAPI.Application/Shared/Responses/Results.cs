

namespace ELibraryAPI.Application.Responses;

public class Result
{
    // 'init' sayəsində obyekt yaradıldıqdan sonra dəyəri dəyişdirilə bilməz
    public bool IsSuccess { get; init; }
    public string? Error { get; init; }

    // Konstruktor protected-dir, yəni kənarda 'new Result()' yazıla bilməz
    protected Result(bool success, string? error)
    {
        IsSuccess = success;
        Error = error;
    }

    public static Result Success() => new(true, null);

    public static Result Failure(string error) => new(false, error);
}

public class Result<T> : Result
{
    public T? Value { get; init; }

    // Konstruktor private-dir, yalnız statik metodlar tərəfindən istifadə olunur
    private Result(T? value, bool success, string? error) : base(success, error)
    {
        Value = value;
    }

    // Uğurlu halda Value mütləq olmalıdır
    public static Result<T> Success(T value) => new(value, true, null);

    // Xəta halında Value default (null) olur
    public static new Result<T> Failure(string error) => new(default, false, error);
}