using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Stock.GetAllStock;

public sealed class GetAllStockQueryHandler : IRequestHandler<GetAllStockQueryRequest, Result<GetAllStockQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStockQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllStockQueryResponse>> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
    {
        var stocks = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Stock, Guid>()
            .GetAll(tracking: false) 
            .OrderBy(s => s.Product.Title)
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .Select(s => new StockListDto(
                s.Id,
                s.ProductId,
                s.Product.Title,
                s.BranchId,
                s.Branch.Name,
                s.Quantity,
                s.Quantity > 0
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllStockQueryResponse>.Success(new GetAllStockQueryResponse(stocks));
    }
}