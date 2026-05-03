using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.UpdateTransaction;

public sealed record UpdateTransactionCommandRequest(
    Guid Id,
    decimal Amount,
    Guid OrderId,
    string ProviderResponse,
    string TransactionId
) : IRequest<Result<UpdateTransactionCommandResponse>>;
