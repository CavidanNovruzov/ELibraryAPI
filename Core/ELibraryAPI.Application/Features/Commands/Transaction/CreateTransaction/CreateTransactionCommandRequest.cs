using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.CreateTransaction;

public sealed record CreateTransactionCommandRequest(
    decimal Amount,
    Guid OrderId,
    string ProviderResponse,
    string TransactionId
) : IRequest<Result<CreateTransactionCommandResponse>>;
