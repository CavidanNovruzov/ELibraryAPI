using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PromoCode.GetAllPromoCode;

public sealed class GetAllPromoCodeQueryHandler : IRequestHandler<GetAllPromoCodeQueryRequest, Result<GetAllPromoCodeQueryResponse>>
{
    public Task<Result<GetAllPromoCodeQueryResponse>> Handle(GetAllPromoCodeQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
