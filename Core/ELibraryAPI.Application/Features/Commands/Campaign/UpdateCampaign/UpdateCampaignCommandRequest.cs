using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Campaign.UpdateCampaign;

public sealed record UpdateCampaignCommandRequest(
    Guid Id,
    string Description,
    decimal DiscountPercent,
    string Title
) : IRequest<Result<UpdateCampaignCommandResponse>>;
