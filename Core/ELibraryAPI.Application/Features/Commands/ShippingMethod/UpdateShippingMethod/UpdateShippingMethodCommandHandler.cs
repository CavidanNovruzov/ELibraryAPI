using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ShippingMethod.UpdateShippingMethod;

public sealed class UpdateShippingMethodCommandHandler : IRequestHandler<UpdateShippingMethodCommandRequest, Result<UpdateShippingMethodCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateShippingMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateShippingMethodCommandResponse>> Handle(UpdateShippingMethodCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ShippingMethod, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ShippingMethod, Guid>();

        var shippingMethod = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (shippingMethod == null)
        {
            return Result<UpdateShippingMethodCommandResponse>.Failure("Shipping method not found.");
        }

        var normalizedName = request.Name.Trim();
        if (shippingMethod.Name.ToLower() != normalizedName.ToLower())
        {
            var isNameExists = await readRepository.ExistsAsync(
                x => x.Name.ToLower() == normalizedName.ToLower() && x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isNameExists)
            {
                return Result<UpdateShippingMethodCommandResponse>.Failure("Another shipping method with this name already exists.");
            }
        }

        if (request.Price < 0)
        {
            return Result<UpdateShippingMethodCommandResponse>.Failure("Shipping price cannot be negative.");
        }

        _mapper.Map(request, shippingMethod);
        shippingMethod.Name = normalizedName;

        writeRepository.Update(shippingMethod);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateShippingMethodCommandResponse>.Success(
            new UpdateShippingMethodCommandResponse(shippingMethod.Id),
            "Shipping method updated successfully.");
    }
}