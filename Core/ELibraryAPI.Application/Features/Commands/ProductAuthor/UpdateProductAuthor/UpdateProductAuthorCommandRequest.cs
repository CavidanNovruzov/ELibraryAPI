using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.UpdateProductAuthor;

public sealed record UpdateProductAuthorCommandRequest(
    Guid Id,
    Guid AuthorId,
    Guid ProductId
) : IRequest<Result<UpdateProductAuthorCommandResponse>>;
