using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Tag.DeleteTag;

public sealed class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommandRequest, Result>
{
    public Task<Result> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
