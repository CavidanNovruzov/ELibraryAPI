
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Basket.GetByIdBasket;

public sealed class GetByIdBasketQueryHandler : IRequestHandler<GetByIdBasketQueryRequest, Result<GetByIdBasketQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdBasketQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetByIdBasketQueryResponse>> Handle(GetByIdBasketQueryRequest request, CancellationToken cancellationToken)
    {
        var basketEntity = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Basket, Guid>()
            .GetAll(tracking: false)
            .Include(b => b.BasketItems)
                .ThenInclude(bi => bi.Product)
                    .ThenInclude(p => p.Images)
            .AsSplitQuery()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (basketEntity == null)
            return Result<GetByIdBasketQueryResponse>.Failure("Basket not found");

        var items = basketEntity.BasketItems.Select(bi =>
        {
            var product = bi.Product;
            var unitPrice = product?.SalePrice ?? 0;
            var quantity = bi.Quantity;
            var mainImage = product?.Images?.FirstOrDefault(i => i.IsMain)?.ImageUrl ?? "";

            return new BasketItemDetailDto(
                bi.Id,
                bi.ProductId,
                product?.Title ?? "Unknown Product",
                mainImage,
                unitPrice,
                quantity,
                unitPrice * quantity 
            );
        }).ToList();

        var totalPrice = items.Sum(x => x.LineTotal);
        var dto = new BasketDetailDto(basketEntity.Id, totalPrice, items);

        return Result<GetByIdBasketQueryResponse>.Success(new GetByIdBasketQueryResponse(dto));
    }
}