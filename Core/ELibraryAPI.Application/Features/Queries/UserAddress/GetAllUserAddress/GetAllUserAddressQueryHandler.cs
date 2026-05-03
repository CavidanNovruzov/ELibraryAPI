//using AutoMapper;
//using ELibraryAPI.Application.Responses;
//using ELibraryAPI.Application.UnitOfWork;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace ELibraryAPI.Application.Features.Queries.UserAddress.GetAllUserAddress;

//public sealed class GetAllUserAddressQueryHandler : IRequestHandler<GetAllUserAddressQueryRequest, Result<GetAllUserAddressQueryResponse>>
//{
//    private readonly IUnitOfWork _unitOfWork;
//    private readonly IMapper _mapper;

//    public GetAllUserAddressQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
//    {
//        _unitOfWork = unitOfWork;
//        _mapper = mapper;
//    }

//    public async Task<Result<GetAllUserAddressQueryResponse>> Handle(GetAllUserAddressQueryRequest request, CancellationToken cancellationToken)
//    {
//        var addresses = await _unitOfWork
//            .ReadRepository<Domain.Entities.Concrete.UserAddress, Guid>()
//            .GetAll(tracking: false, cancellationToken)
//            .Include(ua => ua.User)
//            .ToListAsync(cancellationToken);

//        return Result<GetAllUserAddressQueryResponse>.Success(new GetAllUserAddressQueryResponse());
//    }
//}
