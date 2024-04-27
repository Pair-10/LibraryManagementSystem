using FluentValidation;

namespace Application.Features.MaterialLocations.Commands.Update;

public class UpdateMaterialLocationCommandValidator : AbstractValidator<UpdateMaterialLocationCommand>
{
    public UpdateMaterialLocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LocationId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}