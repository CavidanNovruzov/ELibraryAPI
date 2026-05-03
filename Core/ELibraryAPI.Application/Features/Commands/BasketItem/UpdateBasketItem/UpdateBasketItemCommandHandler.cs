using ELibraryAPI.Application.Features.Commands.BasketItem.UpdateBasketItem;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BasketItem.UpdateBasketItemQuantity;

public sealed class UpdateBasketItemQuantityHandler : IRequestHandler<UpdateBasketItemQuantityRequest, Result<UpdateBasketItemQuantityResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBasketItemQuantityHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UpdateBasketItemQuantityResponse>> Handle(UpdateBasketItemQuantityRequest request, CancellationToken ct)
    {

        var basketItemReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.BasketItem, Guid>();
        var basketItemWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.BasketItem, Guid>();
        var productReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();

        var basketItem = await basketItemReadRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (basketItem == null)
            return Result<UpdateBasketItemQuantityResponse>.Failure("Basket item not found.");

        var product = await productReadRepo.GetByIdAsync(basketItem.ProductId, tracking: false, ct: ct);

        if (product == null)
            return Result<UpdateBasketItemQuantityResponse>.Failure("Associated product not found.");

        if (product.TotalStockCount < request.Quantity)
            return Result<UpdateBasketItemQuantityResponse>.Failure($"Insufficient stock. Available: {product.TotalStockCount}");

        basketItem.Quantity = request.Quantity;
        basketItemWriteRepo.Update(basketItem);

        var result = await _unitOfWork.SaveAsync(ct);

        if (result > 0)
            return Result<UpdateBasketItemQuantityResponse>.Success(new UpdateBasketItemQuantityResponse(basketItem.Id));

        return Result<UpdateBasketItemQuantityResponse>.Failure("An error occurred while updating the quantity.");
    }
}