using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductImage.CreateProductImage;

public sealed class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommandRequest, Result<CreateProductImageCommandResponse>>
{
    public Task<Result<CreateProductImageCommandResponse>> Handle(CreateProductImageCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
