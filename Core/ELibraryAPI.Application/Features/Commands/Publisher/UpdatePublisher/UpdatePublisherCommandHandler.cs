using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Publisher.UpdatePublisher;

public sealed class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommandRequest, Result<UpdatePublisherCommandResponse>>
{
    public Task<Result<UpdatePublisherCommandResponse>> Handle(UpdatePublisherCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
