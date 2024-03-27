using FluentValidation;

namespace Application.Features.MaterialTranslators.Commands.Update;

public class UpdateMaterialTranslatorCommandValidator : AbstractValidator<UpdateMaterialTranslatorCommand>
{
    public UpdateMaterialTranslatorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TranslatorId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}