using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Publisher.DeletePublisher;

public sealed class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommandRequest, Result>
{
    public Task<Result> Handle(DeletePublisherCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
