using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PromoCode.GetByIdPromoCode;

public sealed class GetByIdPromoCodeQueryHandler : IRequestHandler<GetByIdPromoCodeQueryRequest, Result<GetByIdPromoCodeQueryResponse>>
{
    public Task<Result<GetByIdPromoCodeQueryResponse>> Handle(GetByIdPromoCodeQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
