using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.DeleteTransaction;

public sealed record DeleteTransactionCommandRequest(Guid Id) : IRequest<Result>;
