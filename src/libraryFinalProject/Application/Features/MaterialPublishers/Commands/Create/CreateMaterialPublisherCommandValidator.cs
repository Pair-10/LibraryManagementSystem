using FluentValidation;

namespace Application.Features.MaterialPublishers.Commands.Create;

public class CreateMaterialPublisherCommandValidator : AbstractValidator<CreateMaterialPublisherCommand>
{
    public CreateMaterialPublisherCommandValidator()
    {
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.PuslisherId).NotEmpty();
    }
}