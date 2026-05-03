using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Wishlist.GetWishlistByUserId;

public sealed class GetWishlistByUserIdQueryHandler : IRequestHandler<GetWishlistByUserIdQueryRequest, Result<GetWishlistByUserIdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWishlistByUserIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetWishlistByUserIdQueryResponse>> Handle(GetWishlistByUserIdQueryRequest request, CancellationToken cancellationToken)
    {

        var wishlist = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Wishlist, Guid>()
            .GetAll(tracking: false)
            .Where(w => w.UserId == request.UserId)
            .Select(w => new GetWishlistByUserIdQueryResponse(
                w.Id,
                w.WishlistItems.Select(wi => new WishlistItemDto(
                    wi.ProductId,
                    wi.Product.Title,
                    wi.Product.SalePrice,
                    wi.Product.Images.Where(i => i.IsMain).Select(i => i.ImageUrl).FirstOrDefault() ?? ""
                )).ToList()
            ))
            .FirstOrDefaultAsync(cancellationToken);

        if (wishlist == null)
            return Result<GetWishlistByUserIdQueryResponse>.Failure("Wishlist not found for this user.");

        return Result<GetWishlistByUserIdQueryResponse>.Success(wishlist);
    }
}



