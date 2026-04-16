using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Campaign.GetByIdCampaign;

public sealed class GetByIdCampaignQueryHandler : IRequestHandler<GetByIdCampaignQueryRequest, Result<GetByIdCampaignQueryResponse>>
{
    public Task<Result<GetByIdCampaignQueryResponse>> Handle(GetByIdCampaignQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
