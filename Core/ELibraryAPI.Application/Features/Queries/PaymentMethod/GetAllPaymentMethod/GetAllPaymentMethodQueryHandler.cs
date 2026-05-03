using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.PaymentMethod.GetAllPaymentMethod;

public sealed class GetAllPaymentMethodQueryHandler : IRequestHandler<GetAllPaymentMethodQueryRequest, Result<GetAllPaymentMethodQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPaymentMethodQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllPaymentMethodQueryResponse>> Handle(GetAllPaymentMethodQueryRequest request, CancellationToken cancellationToken)
    {
        var methods = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.PaymentMethod, Guid>()
            .GetAll(tracking: false)
            .Select(pm => new PaymentMethodListDto(
                pm.Id,
                pm.Name
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllPaymentMethodQueryResponse>.Success(new GetAllPaymentMethodQueryResponse(methods));
    }
}