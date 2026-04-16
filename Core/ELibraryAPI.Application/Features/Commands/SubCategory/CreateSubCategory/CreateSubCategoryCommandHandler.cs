using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.SubCategory.CreateSubCategory;

public sealed class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommandRequest, Result<CreateSubCategoryCommandResponse>>
{
    public Task<Result<CreateSubCategoryCommandResponse>> Handle(CreateSubCategoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
