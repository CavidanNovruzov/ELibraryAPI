using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Stock.CreateStock;

public sealed class CreateStockCommandHandler : IRequestHandler<CreateStockCommandRequest, Result<CreateStockCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateStockCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateStockCommandResponse>> Handle(CreateStockCommandRequest request, CancellationToken ct)
    {
        var stockReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Stock, Guid>();
        var stockWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Stock, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var branchReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Branch, Guid>();

        // 1. Validate Product existence
        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreateStockCommandResponse>.Failure("Product not found.");
        }

        // 2. Validate Branch existence
        var branchExists = await branchReadRepository.ExistsAsync(x => x.Id == request.BranchId, false, ct);
        if (!branchExists)
        {
            return Result<CreateStockCommandResponse>.Failure("Branch not found.");
        }

        // 3. Prevent duplicate stock records for the same product in the same branch
        var stockAlreadyExists = await stockReadRepository.ExistsAsync(
            x => x.ProductId == request.ProductId && x.BranchId == request.BranchId,
            false,
            ct);

        if (stockAlreadyExists)
        {
            return Result<CreateStockCommandResponse>.Failure("Stock record already exists for this product in the selected branch.");
        }

        // 4. Validate initial quantity
        if (request.Quantity < 0)
        {
            return Result<CreateStockCommandResponse>.Failure("Initial stock quantity cannot be negative.");
        }

        // 5. Map and save
        var stock = _mapper.Map<Domain.Entities.Concrete.Stock>(request);

        await stockWriteRepository.AddAsync(stock, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateStockCommandResponse>.Success(
            new CreateStockCommandResponse(stock.Id),
            "Stock record created successfully.");
    }
}