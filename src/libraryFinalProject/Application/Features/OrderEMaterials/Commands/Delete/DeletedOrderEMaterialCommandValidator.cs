using FluentValidation;

namespace Application.Features.OrderEMaterials.Commands.Delete;

public class DeleteOrderEMaterialCommandValidator : AbstractValidator<DeleteOrderEMaterialCommand>
{
    public DeleteOrderEMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}