using FluentValidation;

namespace Application.Features.MaterialPublishers.Commands.Delete;

public class DeleteMaterialPublisherCommandValidator : AbstractValidator<DeleteMaterialPublisherCommand>
{
    public DeleteMaterialPublisherCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}