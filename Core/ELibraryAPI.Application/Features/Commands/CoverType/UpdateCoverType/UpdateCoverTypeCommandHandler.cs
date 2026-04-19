using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.CoverType.UpdateCoverType;

public sealed class UpdateCoverTypeCommandHandler : IRequestHandler<UpdateCoverTypeCommandRequest, Result<UpdateCoverTypeCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCoverTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateCoverTypeCommandResponse>> Handle(UpdateCoverTypeCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.CoverType, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.CoverType, Guid>();

        var coverType = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (coverType == null)
        {
            return Result<UpdateCoverTypeCommandResponse>.Failure("Cover type not found.");
        }

        if (coverType.Name.ToLower() != request.Name.Trim().ToLower())
        {
            var isNameExists = await readRepo.ExistsAsync(
                x => x.Name.ToLower() == request.Name.Trim().ToLower() && x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isNameExists)
            {
                return Result<UpdateCoverTypeCommandResponse>.Failure("Another cover type with this name already exists.");
            }
        }

        _mapper.Map(request, coverType);

        writeRepo.Update(coverType);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateCoverTypeCommandResponse>.Success(
            new UpdateCoverTypeCommandResponse(coverType.Id),
            "Cover type updated successfully.");
    }
}