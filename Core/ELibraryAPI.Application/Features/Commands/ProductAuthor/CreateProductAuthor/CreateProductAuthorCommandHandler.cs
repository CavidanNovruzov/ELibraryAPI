using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.CreateProductAuthor;

public sealed class CreateProductAuthorCommandHandler : IRequestHandler<CreateProductAuthorCommandRequest, Result<CreateProductAuthorCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateProductAuthorCommandResponse>> Handle(CreateProductAuthorCommandRequest request, CancellationToken ct)
    {
        var productAuthorReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductAuthor, Guid>();
        var productAuthorWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductAuthor, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var authorReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Author, Guid>();

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreateProductAuthorCommandResponse>.Failure("Product not found.");
        }

        var authorExists = await authorReadRepository.ExistsAsync(x => x.Id == request.AuthorId, false, ct);
        if (!authorExists)
        {
            return Result<CreateProductAuthorCommandResponse>.Failure("Author not found.");
        }

        var relationExists = await productAuthorReadRepository.ExistsAsync(
            x => x.ProductId == request.ProductId && x.AuthorId == request.AuthorId,
            false,
            ct);

        if (relationExists)
        {
            return Result<CreateProductAuthorCommandResponse>.Failure("This author is already assigned to this product.");
        }

        var productAuthor = _mapper.Map<Domain.Entities.Concrete.ProductAuthor>(request);

        await productAuthorWriteRepository.AddAsync(productAuthor, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateProductAuthorCommandResponse>.Success(
            new CreateProductAuthorCommandResponse(productAuthor.Id),
            "Author assigned to product successfully.");
    }
}