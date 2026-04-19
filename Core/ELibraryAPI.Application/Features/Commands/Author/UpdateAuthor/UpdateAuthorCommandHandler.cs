using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Author.UpdateAuthor;

public sealed class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, Result<UpdateAuthorCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result<UpdateAuthorCommandResponse>> Handle(UpdateAuthorCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Author, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Author, Guid>();

        var author = await readRepo.GetByIdAsync(request.Id, true, ct);

        if(author == null || author.IsDeleted)
            return Result<UpdateAuthorCommandResponse>.Failure("Author not found.");

        if (author.FullName.ToLower() != request.FullName.ToLower())
        {
            var isNameUsed = await readRepo.ExistsAsync(
                x => x.FullName.ToLower() == request.FullName.ToLower() && !x.IsDeleted,
                tracking: false,
                ct: ct);

            if (isNameUsed)
                return Result<UpdateAuthorCommandResponse>.Failure("An author with this name already exists.");
        }

        _mapper.Map(request, author);

        writeRepo.Update(author);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateAuthorCommandResponse>.Success(new UpdateAuthorCommandResponse(author.Id));
    }
}
