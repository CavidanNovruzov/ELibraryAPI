

using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Auth.Roles.AppRole.CreateRole;

public sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, Result>
{
    private readonly IUnitOfWork _uow;
    public CreateRoleCommandHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Result> Handle(CreateRoleCommandRequest request, CancellationToken ct)
    {
        var readRepository = _uow.ReadRepository<Domain.Entities.Concrete.Auth.AppRole, Guid>();
        var writeRepository = _uow.WriteRepository<Domain.Entities.Concrete.Auth.AppRole, Guid>();

        if (await readRepository.ExistsAsync(r => r.Name == request.Name, false, ct))
            return Result.Failure("A role with this name already exists.");

        var role = new Domain.Entities.Concrete.Auth.AppRole
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            NormalizedName = request.Name.ToUpperInvariant()
        };

        await writeRepository.AddAsync(role, ct);
        return await _uow.SaveAsync(ct) > 0
            ? Result.Success("Role created successfully.")
            : Result.Failure("An error occurred while creating the role.");
    }
}