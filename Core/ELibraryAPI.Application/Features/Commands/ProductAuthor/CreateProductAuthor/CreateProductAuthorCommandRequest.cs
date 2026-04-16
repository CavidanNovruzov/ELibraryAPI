using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.CreateProductAuthor;

public sealed record CreateProductAuthorCommandRequest(
    Guid AuthorId,
    Guid ProductId
) : IRequest<Result<CreateProductAuthorCommandResponse>>;
