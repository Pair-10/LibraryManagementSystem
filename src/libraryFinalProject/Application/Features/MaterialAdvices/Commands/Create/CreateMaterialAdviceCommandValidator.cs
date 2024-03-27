using FluentValidation;

namespace Application.Features.MaterialAdvices.Commands.Create;

public class CreateMaterialAdviceCommandValidator : AbstractValidator<CreateMaterialAdviceCommand>
{
    public CreateMaterialAdviceCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.AuthorName).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.MaterialName).NotEmpty();
    }
}