using FluentValidation;

namespace Application.Features.Locations.Commands.Create;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(c => c.Section).NotEmpty().MaximumLength(3);
        RuleFor(c => c.ShelfNumber).NotEmpty().LessThan(3);
        RuleFor(c => c.ShelfRow).NotEmpty().LessThan(5);
    }
}