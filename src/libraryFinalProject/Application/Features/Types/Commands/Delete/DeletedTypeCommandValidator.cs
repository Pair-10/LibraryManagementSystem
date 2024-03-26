using FluentValidation;

namespace Application.Features.Types.Commands.Delete;

public class DeleteTypeCommandValidator : AbstractValidator<DeleteTypeCommand>
{
    public DeleteTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}