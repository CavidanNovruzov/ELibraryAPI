using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Category.DeleteCategory;

public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Result>
{
    public Task<Result> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
