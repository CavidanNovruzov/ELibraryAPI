using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.WishlistItem.MoveToBasket;

public sealed class MoveToBasketCommandHandler : IRequestHandler<MoveToBasketCommandRequest, Result<MoveToBasketCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public MoveToBasketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MoveToBasketCommandResponse>> Handle(MoveToBasketCommandRequest request, CancellationToken ct)
    {
        var wishItemReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.WishlistItem, Guid>();
        var wishItemWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.WishlistItem, Guid>();
        var basketItemWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.BasketItem, Guid>();
        var basketReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Basket, Guid>();

        var wishlistItem = await wishItemReadRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);
        if (wishlistItem == null)
            return Result<MoveToBasketCommandResponse>.Failure("Wishlist item not found.");

        if (!await basketReadRepo.ExistsAsync(x => x.Id == request.BasketId, false, ct))
            return Result<MoveToBasketCommandResponse>.Failure("Basket not found.");

        var basketItem = new Domain.Entities.Concrete.BasketItem
        {
            BasketId = request.BasketId,
            ProductId = wishlistItem.ProductId,
            Quantity = 1
        };

        await basketItemWriteRepo.AddAsync(basketItem, ct);
        wishItemWriteRepo.Remove(wishlistItem);

        await _unitOfWork.SaveAsync(ct);

        return Result<MoveToBasketCommandResponse>.Success(
            new MoveToBasketCommandResponse(basketItem.Id),
            "Product moved to basket successfully.");
    }
}