using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Publisher.CreatePublisher;

public sealed class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommandRequest, Result<CreatePublisherCommandResponse>>
{
    public Task<Result<CreatePublisherCommandResponse>> Handle(CreatePublisherCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
