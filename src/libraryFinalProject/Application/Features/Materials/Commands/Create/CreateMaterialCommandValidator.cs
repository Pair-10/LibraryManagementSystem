using FluentValidation;

namespace Application.Features.Materials.Commands.Create;

public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator()
    {
        RuleFor(c => c.PublicationDate).NotEmpty();
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.PageCount).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.MaterialName).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
    }
}