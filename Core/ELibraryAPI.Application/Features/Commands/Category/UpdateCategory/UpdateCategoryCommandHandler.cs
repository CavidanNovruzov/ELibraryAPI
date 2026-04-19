using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Category.UpdateCategory;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Result<UpdateCategoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Category, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Category, Guid>();

        var category = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (category == null || category.IsDeleted)
        {
            return Result<UpdateCategoryCommandResponse>.Failure("Category not found.");
        }

        if (category.Name.Trim().ToLower() != request.Name.Trim().ToLower())
        {
            var isNameUsed = await readRepo.ExistsAsync(
                x => x.Name.ToLower() == request.Name.ToLower() && !x.IsDeleted,
                tracking: false,
                ct: ct);

            if (isNameUsed)
            {
                return Result<UpdateCategoryCommandResponse>.Failure("A category with this name already exists.");
            }
        }

        _mapper.Map(request, category);

        writeRepo.Update(category);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateCategoryCommandResponse>.Success(
            new UpdateCategoryCommandResponse(category.Id),
            "Category updated successfully.");
    }
}