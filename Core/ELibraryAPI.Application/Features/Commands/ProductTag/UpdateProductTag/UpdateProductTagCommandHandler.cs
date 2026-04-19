using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.UpdateProductTag;

public sealed class UpdateProductTagCommandHandler : IRequestHandler<UpdateProductTagCommandRequest, Result<UpdateProductTagCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateProductTagCommandResponse>> Handle(UpdateProductTagCommandRequest request, CancellationToken ct)
    {
        var productTagReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductTag, Guid>();
        var productTagWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductTag, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var tagReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Tag, Guid>();

        var productTag = await productTagReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (productTag == null)
        {
            return Result<UpdateProductTagCommandResponse>.Failure("Product-Tag relation not found.");
        }

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<UpdateProductTagCommandResponse>.Failure("Product not found.");
        }

        var tagExists = await tagReadRepository.ExistsAsync(x => x.Id == request.TagId, false, ct);
        if (!tagExists)
        {
            return Result<UpdateProductTagCommandResponse>.Failure("Tag not found.");
        }

        // Check for duplicate relation if ProductId or TagId is changing
        if (productTag.ProductId != request.ProductId || productTag.TagId != request.TagId)
        {
            var relationExists = await productTagReadRepository.ExistsAsync(
                x => x.ProductId == request.ProductId && x.TagId == request.TagId && x.Id != request.Id,
                false,
                ct);

            if (relationExists)
            {
                return Result<UpdateProductTagCommandResponse>.Failure("This tag is already assigned to this product.");
            }
        }

        _mapper.Map(request, productTag);

        productTagWriteRepository.Update(productTag);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateProductTagCommandResponse>.Success(
            new UpdateProductTagCommandResponse(productTag.Id),
            "Product-Tag relation updated successfully.");
    }
}