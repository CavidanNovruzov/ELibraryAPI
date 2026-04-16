using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Category.GetAllCategory;

public sealed class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, Result<GetAllCategoryQueryResponse>>
{
    public Task<Result<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
