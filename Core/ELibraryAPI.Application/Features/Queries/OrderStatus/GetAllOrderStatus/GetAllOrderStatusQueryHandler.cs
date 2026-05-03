using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.OrderStatus.GetAllOrderStatus;

public sealed class GetAllOrderStatusQueryHandler : IRequestHandler<GetAllOrderStatusQueryRequest, Result<GetAllOrderStatusQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrderStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllOrderStatusQueryResponse>> Handle(GetAllOrderStatusQueryRequest request, CancellationToken cancellationToken)
    {
        var statuses = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.OrderStatus, Guid>()
            .GetAll(tracking: false)
            .Select(s => new OrderStatusListDto(s.Id, s.Name))
            .ToListAsync(cancellationToken);

        return Result<GetAllOrderStatusQueryResponse>.Success(new GetAllOrderStatusQueryResponse(statuses));
    }
}