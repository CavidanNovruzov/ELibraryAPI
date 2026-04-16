using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Campaign.GetAllCampaign;

public sealed record GetAllCampaignQueryRequest : IRequest<Result<GetAllCampaignQueryResponse>>;
