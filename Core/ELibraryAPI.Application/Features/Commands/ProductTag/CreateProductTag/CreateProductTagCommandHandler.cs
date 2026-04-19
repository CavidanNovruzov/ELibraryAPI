using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.CreateProductTag;

public sealed class CreateProductTagCommandHandler : IRequestHandler<CreateProductTagCommandRequest, Result<CreateProductTagCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateProductTagCommandResponse>> Handle(CreateProductTagCommandRequest request, CancellationToken ct)
    {
        var productTagReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductTag, Guid>();
        var productTagWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductTag, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var tagReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Tag, Guid>();

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreateProductTagCommandResponse>.Failure("Product not found.");
        }

        var tagExists = await tagReadRepository.ExistsAsync(x => x.Id == request.TagId, false, ct);
        if (!tagExists)
        {
            return Result<CreateProductTagCommandResponse>.Failure("Tag not found.");
        }

        var relationExists = await productTagReadRepository.ExistsAsync(
            x => x.ProductId == request.ProductId && x.TagId == request.TagId,
            false,
            ct);

        if (relationExists)
        {
            return Result<CreateProductTagCommandResponse>.Failure("This tag is already assigned to this product.");
        }

        var productTag = _mapper.Map<Domain.Entities.Concrete.ProductTag>(request);

        await productTagWriteRepository.AddAsync(productTag, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateProductTagCommandResponse>.Success(new CreateProductTagCommandResponse(productTag.Id),"Tag assigned to product successfully.");
    }
}