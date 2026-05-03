using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Language.GetAllLanguage;

public sealed record GetAllLanguageQueryRequest : IRequest<Result<GetAllLanguageQueryResponse>>;
