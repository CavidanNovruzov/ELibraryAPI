using AutoMapper;
using AutoMapper.QueryableExtensions;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.SubCategory.GetAllSubCategory;

public sealed class GetAllSubCategoryQueryHandler : IRequestHandler<GetAllSubCategoryQueryRequest, Result<GetAllSubCategoryQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSubCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllSubCategoryQueryResponse>> Handle(GetAllSubCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var subCategories = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.SubCategory, Guid>()
            .GetAll(tracking: false) 
            .Select(sc => new SubCategoryListDto(
                sc.Id,
                sc.Name,
                sc.CategoryId,
                sc.Category.Name,
                sc.Products.Count
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllSubCategoryQueryResponse>.Success(new GetAllSubCategoryQueryResponse(subCategories));
    }
}