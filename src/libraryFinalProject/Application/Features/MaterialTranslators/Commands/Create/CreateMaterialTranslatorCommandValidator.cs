using FluentValidation;

namespace Application.Features.MaterialTranslators.Commands.Create;

public class CreateMaterialTranslatorCommandValidator : AbstractValidator<CreateMaterialTranslatorCommand>
{
    public CreateMaterialTranslatorCommandValidator()
    {
        RuleFor(c => c.TranslatorId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}