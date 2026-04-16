using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Campaign.CreateCampaign;

public sealed class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommandRequest, Result<CreateCampaignCommandResponse>>
{
    public Task<Result<CreateCampaignCommandResponse>> Handle(CreateCampaignCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
