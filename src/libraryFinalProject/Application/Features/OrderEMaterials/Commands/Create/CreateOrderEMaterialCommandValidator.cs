using FluentValidation;

namespace Application.Features.OrderEMaterials.Commands.Create;

public class CreateOrderEMaterialCommandValidator : AbstractValidator<CreateOrderEMaterialCommand>
{
    public CreateOrderEMaterialCommandValidator()
    {
        RuleFor(c => c.EMaterialId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.QuantityPrice).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty().GreaterThan(0).WithMessage("The quantity ordered must be greater than zero.");
                                                                       //Sipariþ edilen miktar sýfýrdan büyük olmalýdýr.

        RuleFor(c => c.TotalPrice).NotEmpty().GreaterThan(0).WithMessage("The total price must be greater than zero.");
    }                                                                  //Toplam fiyat sýfýrdan büyük olmalýdýr.
}
