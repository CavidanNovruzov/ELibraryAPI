using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductAuthor.GetAllProductAuthor;

public sealed record GetAllProductAuthorQueryRequest : IRequest<Result<GetAllProductAuthorQueryResponse>>;
