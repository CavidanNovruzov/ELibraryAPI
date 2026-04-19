using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Author.CreateAuthor;

public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, Result<CreateAuthorCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateAuthorCommandResponse>> Handle(CreateAuthorCommandRequest request, CancellationToken ct)
    {
       var exists= await _unitOfWork.ReadRepository<Domain.Entities.Concrete.Author,Guid>().ExistsAsync(x=>x.FullName.ToLower() == request.FullName.ToLower() && !x.IsDeleted,false,ct);

        if (exists)
            return Result<CreateAuthorCommandResponse>.Failure("Author already exists.");

        var author = _mapper.Map<Domain.Entities.Concrete.Author>(request);

        await _unitOfWork.WriteRepository<Domain.Entities.Concrete.Author,Guid>().AddAsync(author);

        await _unitOfWork.SaveAsync(ct);

        return Result<CreateAuthorCommandResponse>.Success(new CreateAuthorCommandResponse(author.Id));
    }
      
}
