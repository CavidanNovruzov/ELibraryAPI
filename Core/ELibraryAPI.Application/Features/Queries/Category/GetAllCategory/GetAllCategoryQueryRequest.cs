using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Category.GetAllCategory;

public sealed record GetAllCategoryQueryRequest : IRequest<Result<GetAllCategoryQueryResponse>>;
