using FluentValidation;

namespace Application.Features.Types.Commands.Create;

public class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
{
    public CreateTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}