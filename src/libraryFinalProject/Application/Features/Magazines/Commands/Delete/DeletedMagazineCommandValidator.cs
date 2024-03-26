using FluentValidation;

namespace Application.Features.Magazines.Commands.Delete;

public class DeleteMagazineCommandValidator : AbstractValidator<DeleteMagazineCommand>
{
    public DeleteMagazineCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}