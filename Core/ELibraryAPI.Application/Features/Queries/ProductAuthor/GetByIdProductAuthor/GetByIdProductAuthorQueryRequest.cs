using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductAuthor.GetByIdProductAuthor;

public sealed record GetByIdProductAuthorQueryRequest(Guid Id) : IRequest<Result<GetByIdProductAuthorQueryResponse>>;
