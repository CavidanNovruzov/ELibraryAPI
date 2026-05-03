
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Permission.GetByIdPermission;

public sealed class GetByIdPermissionQueryHandler : IRequestHandler<GetByIdPermissionQueryRequest, Result<GetByIdPermissionQueryResponse>>
{
    private readonly IUnitOfWork _uow;

    public GetByIdPermissionQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Result<GetByIdPermissionQueryResponse>> Handle(GetByIdPermissionQueryRequest request, CancellationToken ct)
    {
        var permission = await _uow.ReadRepository<Domain.Entities.Concrete.Auth.Permission, int>().Table
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(x => new GetByIdPermissionQueryResponse(
                x.Id,
                x.Key,
                x.IsDelegatable,
                x.CreatedDate
            ))
            .FirstOrDefaultAsync(ct);

        if (permission == null)
            return Result<GetByIdPermissionQueryResponse>.Failure("İcazə tapılmadı.");

        return Result<GetByIdPermissionQueryResponse>.Success(permission);
    }
}