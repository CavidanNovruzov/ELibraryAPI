using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Product.UpdateProduct;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Result<UpdateProductCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken ct)
    {
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var productWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Product, Guid>();

        var product = await productReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (product == null)
        {
            return Result<UpdateProductCommandResponse>.Failure("Product not found.");
        }

        // Validate ISBN uniqueness if it has changed
        if (product.ISBN != request.ISBN.Trim())
        {
            var isIsbnExists = await productReadRepository.ExistsAsync(
                x => x.ISBN == request.ISBN.Trim() && x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isIsbnExists)
            {
                return Result<UpdateProductCommandResponse>.Failure("Another product with this ISBN already exists.");
            }
        }

        // Price and Page validation
        if (request.SalePrice <= 0)
        {
            return Result<UpdateProductCommandResponse>.Failure("Sale price must be greater than zero.");
        }

        if (request.DiscountPrice.HasValue && request.DiscountPrice >= request.SalePrice)
        {
            return Result<UpdateProductCommandResponse>.Failure("Discount price must be lower than the sale price.");
        }

        if (request.PageCount <= 0)
        {
            return Result<UpdateProductCommandResponse>.Failure("Page count must be a positive number.");
        }

        _mapper.Map(request, product);

        productWriteRepository.Update(product);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateProductCommandResponse>.Success(
            new UpdateProductCommandResponse(product.Id),
            "Product updated successfully.");
    }
}