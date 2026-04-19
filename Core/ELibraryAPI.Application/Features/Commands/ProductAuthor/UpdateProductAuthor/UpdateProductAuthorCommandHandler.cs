using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.UpdateProductAuthor;

public sealed class UpdateProductAuthorCommandHandler : IRequestHandler<UpdateProductAuthorCommandRequest, Result<UpdateProductAuthorCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateProductAuthorCommandResponse>> Handle(UpdateProductAuthorCommandRequest request, CancellationToken ct)
    {
        var productAuthorReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductAuthor, Guid>();
        var productAuthorWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductAuthor, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var authorReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Author, Guid>();

        var productAuthor = await productAuthorReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (productAuthor == null)
        {
            return Result<UpdateProductAuthorCommandResponse>.Failure("Product-Author relation not found.");
        }

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<UpdateProductAuthorCommandResponse>.Failure("Product not found.");
        }

        var authorExists = await authorReadRepository.ExistsAsync(x => x.Id == request.AuthorId, false, ct);
        if (!authorExists)
        {
            return Result<UpdateProductAuthorCommandResponse>.Failure("Author not found.");
        }

        // Check if the update creates a duplicate relation
        if (productAuthor.ProductId != request.ProductId || productAuthor.AuthorId != request.AuthorId)
        {
            var relationExists = await productAuthorReadRepository.ExistsAsync(
                x => x.ProductId == request.ProductId && x.AuthorId == request.AuthorId && x.Id != request.Id,
                false,
                ct);

            if (relationExists)
            {
                return Result<UpdateProductAuthorCommandResponse>.Failure("This author is already assigned to this product.");
            }
        }

        _mapper.Map(request, productAuthor);

        productAuthorWriteRepository.Update(productAuthor);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateProductAuthorCommandResponse>.Success(
            new UpdateProductAuthorCommandResponse(productAuthor.Id),
            "Product-Author relation updated successfully.");
    }
}