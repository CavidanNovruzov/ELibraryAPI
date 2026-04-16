using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.UpdateProductTag;

public sealed class UpdateProductTagCommandHandler : IRequestHandler<UpdateProductTagCommandRequest, Result<UpdateProductTagCommandResponse>>
{
    public Task<Result<UpdateProductTagCommandResponse>> Handle(UpdateProductTagCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
