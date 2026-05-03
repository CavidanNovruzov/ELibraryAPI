using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using ELibraryAPI.Domain.Entities.Concrete;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Stock.UpdateStock;

public sealed class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommandRequest, Result<UpdateStockCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateStockCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateStockCommandResponse>> Handle(UpdateStockCommandRequest request, CancellationToken ct)
    {
        var stockReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Stock, Guid>();
        var productReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var branchReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Branch, Guid>();

        var stock = await stockReadRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (stock == null)
            return Result<UpdateStockCommandResponse>.Failure("Stock record not found.");

        var productExists = await productReadRepo.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
            return Result<UpdateStockCommandResponse>.Failure("Product not found.");

        var branchExists = await branchReadRepo.ExistsAsync(x => x.Id == request.BranchId, false, ct);
        if (!branchExists)
            return Result<UpdateStockCommandResponse>.Failure("Branch not found.");

        if (stock.ProductId != request.ProductId || stock.BranchId != request.BranchId)
        {
            var stockExists = await stockReadRepo.ExistsAsync(
                x => x.ProductId == request.ProductId && x.BranchId == request.BranchId && x.Id != request.Id,
                false,
                ct);

            if (stockExists)
                return Result<UpdateStockCommandResponse>.Failure("A stock record for this product in the selected branch already exists.");
        }

        if (request.Quantity < 0)
            return Result<UpdateStockCommandResponse>.Failure("Stock quantity cannot be negative.");

        _mapper.Map(request, stock);

        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateStockCommandResponse>.Success(
            new UpdateStockCommandResponse(stock.Id),
            "Stock record updated successfully.");
    }
}