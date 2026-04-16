using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Campaign.UpdateCampaign;

public sealed class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommandRequest, Result<UpdateCampaignCommandResponse>>
{
    public Task<Result<UpdateCampaignCommandResponse>> Handle(UpdateCampaignCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
