using FluentValidation;

namespace Application.Features.Materials.Commands.Update;

public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PublicationDate).NotEmpty();
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.PageCount).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.MaterialName).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
    }
}