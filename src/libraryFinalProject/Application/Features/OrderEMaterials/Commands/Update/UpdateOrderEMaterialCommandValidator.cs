using FluentValidation;

namespace Application.Features.OrderEMaterials.Commands.Update;

public class UpdateOrderEMaterialCommandValidator : AbstractValidator<UpdateOrderEMaterialCommand>
{
    public UpdateOrderEMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EMaterialId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.QuantityPrice).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty();
    }
}