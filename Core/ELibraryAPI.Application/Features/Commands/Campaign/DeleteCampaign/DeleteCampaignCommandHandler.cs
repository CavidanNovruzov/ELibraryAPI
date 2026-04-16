using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Campaign.DeleteCampaign;

public sealed class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommandRequest, Result>
{
    public Task<Result> Handle(DeleteCampaignCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
