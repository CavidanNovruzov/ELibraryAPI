using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.UpdateProductGenre;

public sealed class UpdateProductGenreCommandHandler : IRequestHandler<UpdateProductGenreCommandRequest, Result<UpdateProductGenreCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateProductGenreCommandResponse>> Handle(UpdateProductGenreCommandRequest request, CancellationToken ct)
    {
        var productGenreReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductGenre, Guid>();
        var productGenreWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductGenre, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var genreReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Genre, Guid>();

        var productGenre = await productGenreReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (productGenre == null)
        {
            return Result<UpdateProductGenreCommandResponse>.Failure("Product-Genre relation not found.");
        }

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<UpdateProductGenreCommandResponse>.Failure("Product not found.");
        }

        var genreExists = await genreReadRepository.ExistsAsync(x => x.Id == request.GenreId, false, ct);
        if (!genreExists)
        {
            return Result<UpdateProductGenreCommandResponse>.Failure("Genre not found.");
        }

        if (productGenre.ProductId != request.ProductId || productGenre.GenreId != request.GenreId)
        {
            var relationExists = await productGenreReadRepository.ExistsAsync(
                x => x.ProductId == request.ProductId && x.GenreId == request.GenreId && x.Id != request.Id,
                false,
                ct);

            if (relationExists)
            {
                return Result<UpdateProductGenreCommandResponse>.Failure("This genre is already assigned to this product.");
            }
        }

        _mapper.Map(request, productGenre);

        productGenreWriteRepository.Update(productGenre);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateProductGenreCommandResponse>.Success(
            new UpdateProductGenreCommandResponse(productGenre.Id),
            "Product-Genre relation updated successfully.");
    }
}