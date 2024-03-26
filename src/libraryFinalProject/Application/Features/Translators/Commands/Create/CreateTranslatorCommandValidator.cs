using FluentValidation;

namespace Application.Features.Translators.Commands.Create;

public class CreateTranslatorCommandValidator : AbstractValidator<CreateTranslatorCommand>
{
    public CreateTranslatorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Surname).NotEmpty();
        RuleFor(c => c.Bio).NotEmpty();
        RuleFor(c => c.Website).NotEmpty();
    }
}