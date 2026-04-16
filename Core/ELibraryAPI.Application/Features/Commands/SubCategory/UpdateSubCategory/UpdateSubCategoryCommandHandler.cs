using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.SubCategory.UpdateSubCategory;

public sealed class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommandRequest, Result<UpdateSubCategoryCommandResponse>>
{
    public Task<Result<UpdateSubCategoryCommandResponse>> Handle(UpdateSubCategoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
