using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.DeleteProductAuthor;

public sealed class DeleteProductAuthorCommandHandler : IRequestHandler<DeleteProductAuthorCommandRequest, Result>
{
    public Task<Result> Handle(DeleteProductAuthorCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
