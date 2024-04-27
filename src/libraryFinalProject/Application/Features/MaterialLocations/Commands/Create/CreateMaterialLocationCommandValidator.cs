using FluentValidation;

namespace Application.Features.MaterialLocations.Commands.Create;

public class CreateMaterialLocationCommandValidator : AbstractValidator<CreateMaterialLocationCommand>
{
    public CreateMaterialLocationCommandValidator()
    {
        RuleFor(c => c.LocationId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}