using FluentValidation;

namespace Application.Features.OrderEMaterials.Commands.Create;

public class CreateOrderEMaterialCommandValidator : AbstractValidator<CreateOrderEMaterialCommand>
{
    public CreateOrderEMaterialCommandValidator()
    {
        RuleFor(c => c.EMaterialId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.QuantityPrice).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty().GreaterThan(0);

        RuleFor(c => c.TotalPrice).NotEmpty().GreaterThan(0);
    }
