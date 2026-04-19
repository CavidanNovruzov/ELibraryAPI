using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BranchWorkHours.CreateBranchWorkHours;

public sealed class CreateBranchWorkHoursCommandHandler : IRequestHandler<CreateBranchWorkHoursCommandRequest, Result<CreateBranchWorkHoursCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBranchWorkHoursCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateBranchWorkHoursCommandResponse>> Handle(CreateBranchWorkHoursCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.BranchWorkHours, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.BranchWorkHours, Guid>();

        var isDayExists = await readRepo.ExistsAsync(
            x => x.BranchId == request.BranchId && x.Day == request.Day,
            tracking: false,
            ct: ct);

        if (isDayExists)
        {
            return Result<CreateBranchWorkHoursCommandResponse>.Failure("Work hours for this day already defined for this branch.");
        }

        if (request.OpenTime >= request.CloseTime)
        {
            return Result<CreateBranchWorkHoursCommandResponse>.Failure("Opening time cannot be later than or equal to closing time.");
        }

        var workHours = _mapper.Map<Domain.Entities.Concrete.BranchWorkHours>(request);

        await writeRepo.AddAsync(workHours, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateBranchWorkHoursCommandResponse>.Success(
            new CreateBranchWorkHoursCommandResponse(workHours.Id),
            "Branch work hours created successfully.");
    }
}