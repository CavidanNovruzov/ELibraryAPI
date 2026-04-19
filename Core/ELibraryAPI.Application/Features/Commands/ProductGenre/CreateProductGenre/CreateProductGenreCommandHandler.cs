using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.CreateProductGenre;

public sealed class CreateProductGenreCommandHandler : IRequestHandler<CreateProductGenreCommandRequest, Result<CreateProductGenreCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateProductGenreCommandResponse>> Handle(CreateProductGenreCommandRequest request, CancellationToken ct)
    {
        var productGenreReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductGenre, Guid>();
        var productGenreWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductGenre, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var genreReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Genre, Guid>();

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreateProductGenreCommandResponse>.Failure("Product not found.");
        }

        var genreExists = await genreReadRepository.ExistsAsync(x => x.Id == request.GenreId, false, ct);
        if (!genreExists)
        {
            return Result<CreateProductGenreCommandResponse>.Failure("Genre not found.");
        }

        var relationExists = await productGenreReadRepository.ExistsAsync(
            x => x.ProductId == request.ProductId && x.GenreId == request.GenreId,
            false,
            ct);

        if (relationExists)
        {
            return Result<CreateProductGenreCommandResponse>.Failure("This genre is already assigned to this product.");
        }

        var productGenre = _mapper.Map<Domain.Entities.Concrete.ProductGenre>(request);

        await productGenreWriteRepository.AddAsync(productGenre, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateProductGenreCommandResponse>.Success(
            new CreateProductGenreCommandResponse(productGenre.Id),
            "Genre assigned to product successfully.");
    }
}