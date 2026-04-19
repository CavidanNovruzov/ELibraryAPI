using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Branch.CreateBranch;

public sealed class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommandRequest, Result<CreateBranchCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateBranchCommandResponse>> Handle(CreateBranchCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Branch, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Branch, Guid>();

        var isBranchExists = await readRepo.ExistsAsync(
            x => x.Name.ToLower() == request.Name.Trim().ToLower(),
            tracking: false,
            ct: ct);

        if (isBranchExists)
        {
            return Result<CreateBranchCommandResponse>.Failure("A branch with this name already exists.");
        }

        var branch = _mapper.Map<Domain.Entities.Concrete.Branch>(request);

        await writeRepo.AddAsync(branch, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateBranchCommandResponse>.Success(
            new CreateBranchCommandResponse(branch.Id),
            "Branch created successfully.");
    }
}