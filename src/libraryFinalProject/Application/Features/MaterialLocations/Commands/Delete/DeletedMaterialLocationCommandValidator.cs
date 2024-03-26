using FluentValidation;

namespace Application.Features.MaterialLocations.Commands.Delete;

public class DeleteMaterialLocationCommandValidator : AbstractValidator<DeleteMaterialLocationCommand>
{
    public DeleteMaterialLocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}