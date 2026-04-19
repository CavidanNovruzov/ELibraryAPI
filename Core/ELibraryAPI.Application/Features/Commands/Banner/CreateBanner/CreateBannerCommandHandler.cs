using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Banner.CreateBanner;

using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using ELibraryAPI.Domain.Entities.Concrete;
using MediatR;


public sealed class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommandRequest, Result<CreateBannerCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBannerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateBannerCommandResponse>> Handle(CreateBannerCommandRequest request, CancellationToken ct)
    {
        var writeRepo = _unitOfWork.WriteRepository<Banner, Guid>();

        var banner = _mapper.Map<Banner>(request);

        await writeRepo.AddAsync(banner, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateBannerCommandResponse>.Success(new CreateBannerCommandResponse(banner.Id),"Banner created successfully.");
    }
}