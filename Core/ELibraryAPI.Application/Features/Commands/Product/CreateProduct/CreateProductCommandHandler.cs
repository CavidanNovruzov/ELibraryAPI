using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Product.CreateProduct;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Result<CreateProductCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken ct)
    {
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var productWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Product, Guid>();

        // Check for unique ISBN
        var isIsbnExists = await productReadRepository.ExistsAsync(
            x => x.ISBN == request.ISBN.Trim(),
            tracking: false,
            ct: ct);

        if (isIsbnExists)
        {
            return Result<CreateProductCommandResponse>.Failure("A product with this ISBN already exists.");
        }

        // Validate basic numeric constraints
        if (request.SalePrice <= 0)
        {
            return Result<CreateProductCommandResponse>.Failure("Sale price must be greater than zero.");
        }

        if (request.DiscountPrice.HasValue && request.DiscountPrice >= request.SalePrice)
        {
            return Result<CreateProductCommandResponse>.Failure("Discount price must be lower than the sale price.");
        }

        if (request.PageCount <= 0)
        {
            return Result<CreateProductCommandResponse>.Failure("Page count must be a positive number.");
        }

        // Entity Mapping
        var product = _mapper.Map<Domain.Entities.Concrete.Product>(request);

        // Add Authors
        if (request.AuthorIds != null && request.AuthorIds.Any())
        {
            foreach (var authorId in request.AuthorIds)
            {
                product.ProductAuthors.Add(new Domain.Entities.Concrete.ProductAuthor
                {
                    AuthorId = authorId,
                    ProductId = product.Id
                });
            }
        }

        // Add Genres
        if (request.GenreIds != null && request.GenreIds.Any())
        {
            foreach (var genreId in request.GenreIds)
            {
                product.ProductGenres.Add(new Domain.Entities.Concrete.ProductGenre
                {
                    GenreId = genreId,
                    ProductId = product.Id
                });
            }
        }

        // Add Tags
        if (request.TagIds != null && request.TagIds.Any())
        {
            foreach (var tagId in request.TagIds)
            {
                product.ProductTags.Add(new Domain.Entities.Concrete.ProductTag
                {
                    TagId = tagId,
                    ProductId = product.Id
                });
            }
        }

        // Add Images
        if (request.Images != null && request.Images.Any())
        {
            foreach (var imageDto in request.Images)
            {
                product.Images.Add(new Domain.Entities.Concrete.ProductImage
                {
                    ImageUrl = imageDto.ImageUrl,
                    IsMain = imageDto.IsMain,
                    ProductId = product.Id
                });
            }
        }

        await productWriteRepository.AddAsync(product, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateProductCommandResponse>.Success(
            new CreateProductCommandResponse(product.Id),
            "Product created successfully.");
    }
}