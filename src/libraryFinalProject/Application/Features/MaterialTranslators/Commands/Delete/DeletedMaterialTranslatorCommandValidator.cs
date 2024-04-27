using FluentValidation;

namespace Application.Features.MaterialTranslators.Commands.Delete;

public class DeleteMaterialTranslatorCommandValidator : AbstractValidator<DeleteMaterialTranslatorCommand>
{
    public DeleteMaterialTranslatorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}