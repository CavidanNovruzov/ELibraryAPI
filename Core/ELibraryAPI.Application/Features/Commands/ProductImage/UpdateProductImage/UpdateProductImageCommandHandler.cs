using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductImage.UpdateProductImage;

public sealed class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommandRequest, Result<UpdateProductImageCommandResponse>>
{
    public Task<Result<UpdateProductImageCommandResponse>> Handle(UpdateProductImageCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
