using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Campaign.CreateCampaign;

public sealed record CreateCampaignCommandRequest(
    string Description,
    decimal DiscountPercent,
    string Title
) : IRequest<Result<CreateCampaignCommandResponse>>;
