using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Campaign.GetAllCampaign;

public sealed class GetAllCampaignQueryHandler : IRequestHandler<GetAllCampaignQueryRequest, Result<GetAllCampaignQueryResponse>>
{
    public Task<Result<GetAllCampaignQueryResponse>> Handle(GetAllCampaignQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
