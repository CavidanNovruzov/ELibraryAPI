using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Banner.GetByIdBanner;

public sealed class GetByIdBannerQueryHandler : IRequestHandler<GetByIdBannerQueryRequest, Result<GetByIdBannerQueryResponse>>
{
    public Task<Result<GetByIdBannerQueryResponse>> Handle(GetByIdBannerQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
