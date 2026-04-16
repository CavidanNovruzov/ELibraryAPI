using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.SubCategory.GetAllSubCategory;

public sealed class GetAllSubCategoryQueryHandler : IRequestHandler<GetAllSubCategoryQueryRequest, Result<GetAllSubCategoryQueryResponse>>
{
    public Task<Result<GetAllSubCategoryQueryResponse>> Handle(GetAllSubCategoryQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
