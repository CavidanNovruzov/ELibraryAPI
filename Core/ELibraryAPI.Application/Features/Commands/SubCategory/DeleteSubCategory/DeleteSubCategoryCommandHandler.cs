using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.SubCategory.DeleteSubCategory;

public sealed class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommandRequest, Result>
{
    public Task<Result> Handle(DeleteSubCategoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
