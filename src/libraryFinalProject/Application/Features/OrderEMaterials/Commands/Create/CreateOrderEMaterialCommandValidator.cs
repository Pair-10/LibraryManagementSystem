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
                                                                       //Sipari� edilen miktar s�f�rdan b�y�k olmal�d�r.

        RuleFor(c => c.TotalPrice).NotEmpty().GreaterThan(0).WithMessage("The total price must be greater than zero.");
    }                                                                  //Toplam fiyat s�f�rdan b�y�k olmal�d�r.
}
