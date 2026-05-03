using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserSearchHistory.UpdateUserSearchHistory;

public sealed class UpdateUserSearchHistoryCommandHandler : IRequestHandler<UpdateUserSearchHistoryCommandRequest, Result<UpdateUserSearchHistoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserSearchHistoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateUserSearchHistoryCommandResponse>> Handle(UpdateUserSearchHistoryCommandRequest request, CancellationToken ct)
    {
        var historyReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.UserSearchHistory, Guid>();
        var historyWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.UserSearchHistory, Guid>();
        var userReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Auth.AppUser, Guid>();

        var historyRecord = await historyReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);
        if (historyRecord == null)
        {
            return Result<UpdateUserSearchHistoryCommandResponse>.Failure("Search history record not found.");
        }

        if (historyRecord.UserId != request.UserId)
        {
            var userExists = await userReadRepository.ExistsAsync(x => x.Id == request.UserId, false, ct);
            if (!userExists)
            {
                return Result<UpdateUserSearchHistoryCommandResponse>.Failure("Target user not found.");
            }
        }

        var normalizedQuery = request.SearchQuery?.Trim();
        if (string.IsNullOrWhiteSpace(normalizedQuery))
        {
            return Result<UpdateUserSearchHistoryCommandResponse>.Failure("Search query cannot be empty.");
        }

        _mapper.Map(request, historyRecord);
        historyRecord.SearchQuery = normalizedQuery;

        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateUserSearchHistoryCommandResponse>.Success(
            new UpdateUserSearchHistoryCommandResponse(historyRecord.Id),
            "Search history record updated successfully.");
    }
}