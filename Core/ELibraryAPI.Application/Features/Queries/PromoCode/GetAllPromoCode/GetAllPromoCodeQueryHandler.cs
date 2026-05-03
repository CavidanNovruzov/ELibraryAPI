using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.PromoCode.GetAllPromoCode;

public sealed class GetAllPromoCodeQueryHandler : IRequestHandler<GetAllPromoCodeQueryRequest, Result<GetAllPromoCodeQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPromoCodeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllPromoCodeQueryResponse>> Handle(GetAllPromoCodeQueryRequest request, CancellationToken cancellationToken)
    {
        var promoCodes = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.PromoCode, Guid>()
            .GetAll(tracking: false, cancellationToken)
            .Where(pc => !pc.IsDeleted)
            .Select(pc => new PromoCodeListDto(
                pc.Id,
                pc.Code,
                pc.DiscountPercent,
                pc.StartDate,
                pc.EndDate,
                pc.UsageLimit
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllPromoCodeQueryResponse>.Success(new GetAllPromoCodeQueryResponse(promoCodes));
    }
}
