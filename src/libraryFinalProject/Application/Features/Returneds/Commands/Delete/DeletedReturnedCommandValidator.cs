using FluentValidation;

namespace Application.Features.Returneds.Commands.Delete;

public class DeleteReturnedCommandValidator : AbstractValidator<DeleteReturnedCommand>
{
    public DeleteReturnedCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}