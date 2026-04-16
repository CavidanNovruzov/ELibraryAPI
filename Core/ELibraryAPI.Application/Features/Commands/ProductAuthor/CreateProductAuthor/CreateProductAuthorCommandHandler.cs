using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.CreateProductAuthor;

public sealed class CreateProductAuthorCommandHandler : IRequestHandler<CreateProductAuthorCommandRequest, Result<CreateProductAuthorCommandResponse>>
{
    public Task<Result<CreateProductAuthorCommandResponse>> Handle(CreateProductAuthorCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
