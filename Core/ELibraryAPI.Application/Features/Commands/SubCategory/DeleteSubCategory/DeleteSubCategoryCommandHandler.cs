using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.SubCategory.DeleteSubCategory;

public sealed class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSubCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSubCategoryCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.SubCategory, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.SubCategory, Guid>();

        var subCategory = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (subCategory == null)
        {
            return Result.Failure("Sub-category not found.");
        }

        subCategory.IsDeleted = true;
        writeRepository.Update(subCategory);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Sub-category deleted successfully.");
    }
}