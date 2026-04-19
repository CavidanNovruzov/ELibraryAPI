using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductImage.CreateProductImage;

public sealed class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommandRequest, Result<CreateProductImageCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductImageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateProductImageCommandResponse>> Handle(CreateProductImageCommandRequest request, CancellationToken ct)
    {
        var productImageWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductImage, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreateProductImageCommandResponse>.Failure("Product not found.");
        }

        if (string.IsNullOrWhiteSpace(request.ImageUrl))
        {
            return Result<CreateProductImageCommandResponse>.Failure("Image URL cannot be empty.");
        }

        var productImage = _mapper.Map<Domain.Entities.Concrete.ProductImage>(request);

        await productImageWriteRepository.AddAsync(productImage, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateProductImageCommandResponse>.Success(
            new CreateProductImageCommandResponse(productImage.Id),
            "Product image uploaded successfully.");
    }
}