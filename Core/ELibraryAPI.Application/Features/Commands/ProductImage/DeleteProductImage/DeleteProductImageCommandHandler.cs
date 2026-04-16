using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductImage.DeleteProductImage;

public sealed class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, Result>
{
    public Task<Result> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
