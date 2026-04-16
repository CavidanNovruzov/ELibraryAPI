using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.DeleteProductTag;

public sealed class DeleteProductTagCommandHandler : IRequestHandler<DeleteProductTagCommandRequest, Result>
{
    public Task<Result> Handle(DeleteProductTagCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
