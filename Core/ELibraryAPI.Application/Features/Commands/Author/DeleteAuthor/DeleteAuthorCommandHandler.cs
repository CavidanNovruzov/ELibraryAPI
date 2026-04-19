using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Author.DeleteAuthor;

public sealed class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result> Handle(DeleteAuthorCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Author, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Author, Guid>();

        var author = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (author == null || author.IsDeleted)
            return Result.Failure("Author not found or already deleted.");

        author.IsDeleted = true;

        writeRepo.Update(author);
        await _unitOfWork.SaveAsync(ct);

        return Result.Success();
    }
}
