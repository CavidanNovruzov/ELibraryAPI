using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Author.GetByIdAuthor;

public sealed record GetByIdAuthorQueryRequest(Guid Id) : IRequest<Result<GetByIdAuthorQueryResponse>>;
