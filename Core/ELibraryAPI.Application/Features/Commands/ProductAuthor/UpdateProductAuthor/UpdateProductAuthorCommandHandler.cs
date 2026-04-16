using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.UpdateProductAuthor;

public sealed class UpdateProductAuthorCommandHandler : IRequestHandler<UpdateProductAuthorCommandRequest, Result<UpdateProductAuthorCommandResponse>>
{
    public Task<Result<UpdateProductAuthorCommandResponse>> Handle(UpdateProductAuthorCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
