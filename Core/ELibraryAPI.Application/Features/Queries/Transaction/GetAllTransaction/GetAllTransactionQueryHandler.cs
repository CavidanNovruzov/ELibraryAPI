using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ELibraryAPI.Application.Features.Queries.Transaction.GetAllTransaction;

public sealed class GetAllTransactionQueryHandler : IRequestHandler<GetAllTransactionQueryRequest, Result<GetAllTransactionQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTransactionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllTransactionQueryResponse>> Handle(GetAllTransactionQueryRequest request, CancellationToken cancellationToken)
    {
        var transactions = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Transaction, Guid>()
            .GetAll(tracking: false)
            .OrderByDescending(t => t.CreatedDate)
            .Select(t => new TransactionListDto(
                t.Id,
                t.OrderId,
                t.Amount,
                t.Status.ToString(), 
                t.CreatedDate
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllTransactionQueryResponse>.Success(new GetAllTransactionQueryResponse(transactions));
    }
}

