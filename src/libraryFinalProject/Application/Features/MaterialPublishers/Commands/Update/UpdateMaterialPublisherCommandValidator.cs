using FluentValidation;

namespace Application.Features.MaterialPublishers.Commands.Update;

public class UpdateMaterialPublisherCommandValidator : AbstractValidator<UpdateMaterialPublisherCommand>
{
    public UpdateMaterialPublisherCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.PuslisherId).NotEmpty();
    }
}