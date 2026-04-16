using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Category.GetByIdCategory;

public sealed class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, Result<GetByIdCategoryQueryResponse>>
{
    public Task<Result<GetByIdCategoryQueryResponse>> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
