using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Publisher.UpdatePublisher;

public sealed class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommandRequest, Result<UpdatePublisherCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdatePublisherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result<UpdatePublisherCommandResponse>> Handle(UpdatePublisherCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Publisher, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Publisher, Guid>();

        var publisher = await readRepo.GetByIdAsync(request.Id, true, ct);

        if (publisher == null || publisher.IsDeleted)
            return Result<UpdatePublisherCommandResponse>.Failure("Publisher not found.");

        if (publisher.Name.ToLower() != request.Name.ToLower())
        {
            var isNameUsed = await readRepo.ExistsAsync(
                x => x.Name.ToLower() == request.Name.ToLower() && !x.IsDeleted,
                tracking: false,
                ct: ct);

            if (isNameUsed)
                return Result<UpdatePublisherCommandResponse>.Failure("A publisher with this name already exists.");
        }

        _mapper.Map(request, publisher);

        writeRepo.Update(publisher);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdatePublisherCommandResponse>.Success(new UpdatePublisherCommandResponse(publisher.Id), "Publisher updated successfully.");
    }
}
