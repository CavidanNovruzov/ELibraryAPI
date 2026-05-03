using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.SubCategory.GetAllSubCategory;

public sealed record GetAllSubCategoryQueryRequest : IRequest<Result<GetAllSubCategoryQueryResponse>>;
