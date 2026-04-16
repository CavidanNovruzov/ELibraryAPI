using ELibraryAPI.Application.Features.Commands.Publisher.UpdatePublisher;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Publisher;

public sealed class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommandRequest>
{
    public UpdatePublisherCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
