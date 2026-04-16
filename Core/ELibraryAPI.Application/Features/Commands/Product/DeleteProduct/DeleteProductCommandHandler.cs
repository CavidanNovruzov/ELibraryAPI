using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Product.DeleteProduct;

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, Result>
{
    public Task<Result> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
