using FluentValidation;

namespace Application.Features.Types.Commands.Update;

public class UpdateTypeCommandValidator : AbstractValidator<UpdateTypeCommand>
{
    public UpdateTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}