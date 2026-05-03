using ELibraryAPI.Application.Responses;
using FluentValidation;
using MediatR;

namespace ELibraryAPI.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f is not null)
                .ToList();

            if (failures.Count != 0)
            {
                var message = string.Join(" | ", failures.Select(f => f.ErrorMessage));

                // This app uses Result/Result<T> as the standard envelope.
                if (typeof(TResponse) == typeof(Result))
                    return (TResponse)(object)Result.Failure(message);

                if (typeof(TResponse).IsGenericType &&
                    typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var failureMethod = typeof(TResponse)
                        .GetMethod(nameof(Result<object>.Failure), new[] { typeof(string) });

                    if (failureMethod is not null)
                        return (TResponse)failureMethod.Invoke(null, new object?[] { message })!;
                }

                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}

