using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
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
        var stockReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Stock, Guid>();
        var stockWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Stock, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var branchReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Branch, Guid>();

        var stock = await stockReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (stock == null)
        {
            return Result<UpdateStockCommandResponse>.Failure("Stock record not found.");
        }

        // 1. Verify Product exists
        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<UpdateStockCommandResponse>.Failure("Product not found.");
        }

        // 2. Verify Branch exists
        var branchExists = await branchReadRepository.ExistsAsync(x => x.Id == request.BranchId, false, ct);
        if (!branchExists)
        {
            return Result<UpdateStockCommandResponse>.Failure("Branch not found.");
        }

        // 3. Check for duplicate stock record if IDs are changing
        if (stock.ProductId != request.ProductId || stock.BranchId != request.BranchId)
        {
            var stockExists = await stockReadRepository.ExistsAsync(
                x => x.ProductId == request.ProductId && x.BranchId == request.BranchId && x.Id != request.Id,
                false,
                ct);

            if (stockExists)
            {
                return Result<UpdateStockCommandResponse>.Failure("A stock record for this product in the selected branch already exists.");
            }
        }

        // 4. Validate Quantity
        if (request.Quantity < 0)
        {
            return Result<UpdateStockCommandResponse>.Failure("Stock quantity cannot be negative.");
        }

        // 5. Map and save
        _mapper.Map(request, stock);

        stockWriteRepository.Update(stock);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateStockCommandResponse>.Success(
            new UpdateStockCommandResponse(stock.Id),
            "Stock record updated successfully.");
    }
}