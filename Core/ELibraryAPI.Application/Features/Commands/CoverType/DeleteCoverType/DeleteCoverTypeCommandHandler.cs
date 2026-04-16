using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.CoverType.DeleteCoverType;

public sealed class DeleteCoverTypeCommandHandler : IRequestHandler<DeleteCoverTypeCommandRequest, Result>
{
    public Task<Result> Handle(DeleteCoverTypeCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
