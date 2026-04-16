using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.CreateProductTag;

public sealed class CreateProductTagCommandHandler : IRequestHandler<CreateProductTagCommandRequest, Result<CreateProductTagCommandResponse>>
{
    public Task<Result<CreateProductTagCommandResponse>> Handle(CreateProductTagCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
