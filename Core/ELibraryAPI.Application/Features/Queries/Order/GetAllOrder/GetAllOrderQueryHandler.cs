using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Order.GetAllOrder;

public sealed class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, Result<GetAllOrderQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrderQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Order, Guid>()
            .GetAll(tracking: false)
            .OrderByDescending(o => o.CreatedDate) 
            .Select(o => new OrderListDto(
                o.Id,
                o.OrderNumber,
                o.CreatedDate,
                o.TotalAmount,
                o.OrderStatus.Name,
                o.User.Email,
                o.OrderItems.Count
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllOrderQueryResponse>.Success(new GetAllOrderQueryResponse(orders));
    }
}