using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BasketItem.CreateBasketItem;

public sealed class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest, Result<CreateBasketItemCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBasketItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateBasketItemCommandResponse>> Handle(CreateBasketItemCommandRequest request, CancellationToken ct)
    {
        var basketItemReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.BasketItem, Guid>();
        var basketItemWriteRepo = _unitOfWork.WriteRepository<  Domain.Entities.Concrete.BasketItem, Guid>();
        var productReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();

        // 1. Product & Stock Check
        var product = await productReadRepo.GetByIdAsync(request.ProductId, tracking: false, ct: ct);

        if (product == null)
            return Result<CreateBasketItemCommandResponse>.Failure("Product not found.");

        // 2. Upsert Logic: Check if item already exists in the basket
        var existingItem = await basketItemReadRepo.GetSingleAsync(
            x => x.BasketId == request.BasketId && x.ProductId == request.ProductId,
            tracking: true, ct: ct);

        if (existingItem != null)
        {
            // If exists: Increase quantity
            int totalDesiredQuantity = existingItem.Quantity + request.Quantity;

            // Stock check with TotalStockCount
            if (product.TotalStockCount < totalDesiredQuantity)
                return Result<CreateBasketItemCommandResponse>.Failure($"Insufficient stock. Available stock: {product.TotalStockCount}");

            existingItem.Quantity = totalDesiredQuantity;
            basketItemWriteRepo.Update(existingItem);
        }
        else
        {
            // If not exists: Create new item
            if (product.TotalStockCount < request.Quantity)
                return Result<CreateBasketItemCommandResponse>.Failure($"Only {product.TotalStockCount} items available in stock.");

            existingItem = _mapper.Map<Domain.Entities.Concrete.BasketItem>(request);
            await basketItemWriteRepo.AddAsync(existingItem, ct);
        }

        var result = await _unitOfWork.SaveAsync(ct);

        if (result > 0)
            return Result<CreateBasketItemCommandResponse>.Success(new CreateBasketItemCommandResponse(existingItem.Id));

        return Result<CreateBasketItemCommandResponse>.Failure("An error occurred while adding the item to the basket.");
    }
}