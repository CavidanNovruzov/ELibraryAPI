using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.SubCategory.UpdateSubCategory;

public sealed class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommandRequest, Result<UpdateSubCategoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateSubCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateSubCategoryCommandResponse>> Handle(UpdateSubCategoryCommandRequest request, CancellationToken ct)
    {
        var subCategoryReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.SubCategory, Guid>();
        var subCategoryWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.SubCategory, Guid>();
        var categoryReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Category, Guid>();

        var subCategory = await subCategoryReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (subCategory == null)
        {
            return Result<UpdateSubCategoryCommandResponse>.Failure("Sub-category not found.");
        }

        // 1. Verify parent Category exists
        var categoryExists = await categoryReadRepository.ExistsAsync(x => x.Id == request.CategoryId, false, ct);
        if (!categoryExists)
        {
            return Result<UpdateSubCategoryCommandResponse>.Failure("Parent category not found.");
        }

        // 2. Check for duplicate name within the same category (if name or category is changing)
        var normalizedName = request.Name.Trim();
        if (subCategory.Name.ToLower() != normalizedName.ToLower() || subCategory.CategoryId != request.CategoryId)
        {
            var isNameExists = await subCategoryReadRepository.ExistsAsync(
                x => x.Name.ToLower() == normalizedName.ToLower() &&
                     x.CategoryId == request.CategoryId &&
                     x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isNameExists)
            {
                return Result<UpdateSubCategoryCommandResponse>.Failure("Another sub-category with this name already exists in the selected category.");
            }
        }

        // 3. Map changes and persist
        _mapper.Map(request, subCategory);
        subCategory.Name = normalizedName;

        subCategoryWriteRepository.Update(subCategory);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateSubCategoryCommandResponse>.Success(
            new UpdateSubCategoryCommandResponse(subCategory.Id),
            "Sub-category updated successfully.");
    }
}