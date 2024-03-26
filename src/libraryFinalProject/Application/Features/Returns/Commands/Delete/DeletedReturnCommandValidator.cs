using FluentValidation;

namespace Application.Features.Returns.Commands.Delete;

public class DeleteReturnCommandValidator : AbstractValidator<DeleteReturnCommand>
{
    public DeleteReturnCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}