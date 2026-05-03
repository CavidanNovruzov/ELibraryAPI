using ELibraryAPI.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ELibraryAPI.Application.Behaviors;

public sealed class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

    public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex, "Unhandled exception for {RequestName}", requestName);

            if (typeof(TResponse) == typeof(Result))
                return (TResponse)(object)Result.Failure("Unexpected error occurred.");

            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                var failureMethod = typeof(TResponse)
                    .GetMethod(nameof(Result<object>.Failure), new[] { typeof(string) });

                if (failureMethod is not null)
                    return (TResponse)failureMethod.Invoke(null, new object?[] { "Unexpected error occurred." })!;
            }

            throw;
        }
    }
}

