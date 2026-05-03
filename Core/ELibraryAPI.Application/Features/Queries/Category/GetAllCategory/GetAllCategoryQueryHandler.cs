using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Category.GetAllCategory;

public sealed class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, Result<GetAllCategoryQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Category, Guid>()
            .GetAll(tracking: false)
            .Where(c => !c.IsDeleted)
            .Select(c => new CategoryListDto(
                c.Id,
                c.Name,
                c.SubCategories.Count, 
                c.SubCategories.SelectMany(sc => sc.Products).Count()
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllCategoryQueryResponse>.Success(new GetAllCategoryQueryResponse(categories));
    }
}