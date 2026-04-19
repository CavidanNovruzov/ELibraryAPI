using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Language.DeleteLanguage;

public sealed class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteLanguageCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Language, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Language, Guid>();

        var language = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (language == null)
        {
            return Result.Failure("Language not found.");
        }

        language.IsDeleted = true;
        writeRepo.Update(language);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Language deleted successfully.");
    }
}