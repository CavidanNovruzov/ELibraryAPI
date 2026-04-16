using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Banner.GetAllBanner;

public sealed class GetAllBannerQueryHandler : IRequestHandler<GetAllBannerQueryRequest, Result<GetAllBannerQueryResponse>>
{
    public Task<Result<GetAllBannerQueryResponse>> Handle(GetAllBannerQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
