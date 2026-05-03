namespace ELibraryAPI.Application.Features.Queries.Transaction.GetAllTransaction;

public sealed record GetAllTransactionQueryResponse(List<TransactionListDto> Transactions);

public sealed record TransactionListDto(Guid Id, Guid OrderId, decimal Amount, string Status, DateTime CreatedDate);
