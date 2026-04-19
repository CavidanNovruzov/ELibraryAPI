using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserAddress.CreateUserAddress;

public sealed class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommandRequest, Result<CreateUserAddressCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateUserAddressCommandResponse>> Handle(CreateUserAddressCommandRequest request, CancellationToken ct)
    {
        var addressWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.UserAddress, Guid>();
        var userReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Auth.AppUser, Guid>();

        // 1. Verify user exists
        var userExists = await userReadRepository.ExistsAsync(x => x.Id == request.UserId, false, ct);
        if (!userExists)
        {
            return Result<CreateUserAddressCommandResponse>.Failure("User not found.");
        }

        // 2. Validate address content
        if (string.IsNullOrWhiteSpace(request.AddressLine))
        {
            return Result<CreateUserAddressCommandResponse>.Failure("Address line cannot be empty.");
        }

        // 3. Map and persist
        var userAddress = _mapper.Map<Domain.Entities.Concrete.UserAddress>(request);
        userAddress.AddressLine = request.AddressLine.Trim();

        await addressWriteRepository.AddAsync(userAddress, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateUserAddressCommandResponse>.Success(
            new CreateUserAddressCommandResponse(userAddress.Id),
            "User address created successfully.");
    }
}