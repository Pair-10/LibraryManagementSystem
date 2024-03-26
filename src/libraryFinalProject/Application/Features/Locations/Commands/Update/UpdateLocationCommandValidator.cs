using FluentValidation;

namespace Application.Features.Locations.Commands.Update;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Section).NotEmpty();
        RuleFor(c => c.ShelfNumber).NotEmpty();
        RuleFor(c => c.ShelfRow).NotEmpty();
    }
}