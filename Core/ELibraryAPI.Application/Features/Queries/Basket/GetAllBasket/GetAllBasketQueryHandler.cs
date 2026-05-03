using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Basket.GetAllBasket;

public sealed class GetAllBasketQueryHandler : IRequestHandler<GetAllBasketQueryRequest, Result<GetAllBasketQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBasketQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllBasketQueryResponse>> Handle(GetAllBasketQueryRequest request, CancellationToken ct)
    {
        var baskets = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Basket, Guid>()
            .GetAll(tracking: false)
            .Select(b => new BasketListDto(
                b.Id,
                b.UserId,
                b.User.Email ?? string.Empty,
                b.BasketItems.Sum(bi => bi.Product.SalePrice * bi.Quantity),
                b.BasketItems.Count
            ))
            .ToListAsync(ct);

        return Result<GetAllBasketQueryResponse>.Success(new GetAllBasketQueryResponse(baskets));
    }
}