using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Publisher.CreatePublisher;

public sealed class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommandRequest, Result<CreatePublisherCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePublisherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreatePublisherCommandResponse>> Handle(CreatePublisherCommandRequest request, CancellationToken ct)
    {
        var exists = await _unitOfWork.ReadRepository<Domain.Entities.Concrete.Publisher, Guid>()
            .ExistsAsync(
                predicate: x => x.Name.ToLower() == request.Name.ToLower() && !x.IsDeleted,
                tracking: false,
                ct: ct);

        if (exists)
            return Result<CreatePublisherCommandResponse>.Failure("A publisher with this name already exists.");

        var publisher = _mapper.Map<Domain.Entities.Concrete.Publisher>(request);

        await _unitOfWork.WriteRepository<Domain.Entities.Concrete.Publisher, Guid>().AddAsync(publisher, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreatePublisherCommandResponse>.Success(new CreatePublisherCommandResponse(publisher.Id));
    }
}