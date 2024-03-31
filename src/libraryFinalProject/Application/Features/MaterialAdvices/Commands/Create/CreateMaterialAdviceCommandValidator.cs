using FluentValidation;

namespace Application.Features.MaterialAdvices.Commands.Create;

public class CreateMaterialAdviceCommandValidator : AbstractValidator<CreateMaterialAdviceCommand>
{
    public CreateMaterialAdviceCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.AuthorName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.MaterialName).NotEmpty().MinimumLength(2).MaximumLength(50);
    }
}