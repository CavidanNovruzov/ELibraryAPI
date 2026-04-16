using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.SubCategory.GetByIdSubCategory;

public sealed class GetByIdSubCategoryQueryHandler : IRequestHandler<GetByIdSubCategoryQueryRequest, Result<GetByIdSubCategoryQueryResponse>>
{
    public Task<Result<GetByIdSubCategoryQueryResponse>> Handle(GetByIdSubCategoryQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
