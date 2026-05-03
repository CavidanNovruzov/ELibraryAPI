using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.ShippingMethod.GetAllShippingMethod;

public sealed class GetAllShippingMethodQueryHandler : IRequestHandler<GetAllShippingMethodQueryRequest, Result<GetAllShippingMethodQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllShippingMethodQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllShippingMethodQueryResponse>> Handle(GetAllShippingMethodQueryRequest request, CancellationToken cancellationToken)
    {
        var methods = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.ShippingMethod, Guid>()
            .GetAll(tracking: false) 
            .Select(sm => new ShippingMethodListDto(
                sm.Id,
                sm.Name,
                sm.Price
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllShippingMethodQueryResponse>.Success(new GetAllShippingMethodQueryResponse(methods));
    }
}
