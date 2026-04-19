using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Branch.UpdateBranch;

public sealed class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommandRequest, Result<UpdateBranchCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateBranchCommandResponse>> Handle(UpdateBranchCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Branch, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Branch, Guid>();

        var branch = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (branch == null)
        {
            return Result<UpdateBranchCommandResponse>.Failure("Branch not found.");
        }

        if (branch.Name.ToLower() != request.Name.Trim().ToLower())
        {
            var isNameExists = await readRepo.ExistsAsync(
                x => x.Name.ToLower() == request.Name.Trim().ToLower() && x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isNameExists)
            {
                return Result<UpdateBranchCommandResponse>.Failure("Another branch with this name already exists.");
            }
        }

        _mapper.Map(request, branch);

        writeRepo.Update(branch);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateBranchCommandResponse>.Success(
            new UpdateBranchCommandResponse(branch.Id),
            "Branch updated successfully.");
    }
}