using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Author.GetAllAuthor;

public sealed record GetAllAuthorQueryRequest(int PageNumber = 1,
    int PageSize = 10, 
    string? SearchTerm = null
    ) : IRequest<Result<GetAllAuthorQueryResponse>>;