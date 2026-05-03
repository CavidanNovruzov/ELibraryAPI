

using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.PromoCode.CheckPromoCode
{
    public sealed class CheckPromoCodeQueryHandler : IRequestHandler<CheckPromoCodeQueryRequest, Result<CheckPromoCodeQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckPromoCodeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CheckPromoCodeQueryResponse>> Handle(CheckPromoCodeQueryRequest request, CancellationToken cancellationToken)
        {
            var promo = await _unitOfWork
                .ReadRepository<Domain.Entities.Concrete.PromoCode, Guid>()
                .GetAll(tracking: false)
                .FirstOrDefaultAsync(pc => pc.Code == request.Code, cancellationToken);

            if (promo == null)
                return Result<CheckPromoCodeQueryResponse>.Failure("Belə bir promo kod yoxdur.");

            if (promo.EndDate < DateTime.Now)
                return Result<CheckPromoCodeQueryResponse>.Failure("Bu promo kodun vaxtı bitib.");


            return Result<CheckPromoCodeQueryResponse>.Success(new CheckPromoCodeQueryResponse(
                promo.Code,
                promo.DiscountPercent,
                "Promo kod uğurla tətbiq edildi."));
        }
    }
}
