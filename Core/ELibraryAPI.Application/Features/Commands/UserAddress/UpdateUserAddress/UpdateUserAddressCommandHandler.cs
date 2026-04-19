using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserAddress.UpdateUserAddress;

public sealed class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommandRequest, Result<UpdateUserAddressCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateUserAddressCommandResponse>> Handle(UpdateUserAddressCommandRequest request, CancellationToken ct)
    {
        var addressReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.UserAddress, Guid>();
        var addressWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.UserAddress, Guid>();
        var userReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Auth.AppUser, Guid>();

        // 1. Check if address exists
        var address = await addressReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);
        if (address == null)
        {
            return Result<UpdateUserAddressCommandResponse>.Failure("Address record not found.");
        }

        // 2. If UserId is changing, verify the new user exists
        if (address.UserId != request.UserId)
        {
            var userExists = await userReadRepository.ExistsAsync(x => x.Id == request.UserId, false, ct);
            if (!userExists)
            {
                return Result<UpdateUserAddressCommandResponse>.Failure("Target user not found.");
            }
        }

        // 3. Validate address content
        var normalizedAddress = request.AddressLine?.Trim();
        if (string.IsNullOrWhiteSpace(normalizedAddress))
        {
            return Result<UpdateUserAddressCommandResponse>.Failure("Address line cannot be empty.");
        }

        // 4. Map changes and persist
        _mapper.Map(request, address);
        address.AddressLine = normalizedAddress;

        addressWriteRepository.Update(address);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateUserAddressCommandResponse>.Success(
            new UpdateUserAddressCommandResponse(address.Id),
            "User address updated successfully.");
    }
}