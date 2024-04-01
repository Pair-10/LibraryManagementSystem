using FluentValidation;

namespace Application.Features.BasketEmaterials.Commands.Create;

public class CreateBasketEmaterialCommandValidator : AbstractValidator<CreateBasketEmaterialCommand>
{
    public CreateBasketEmaterialCommandValidator()
    {
        RuleFor(c => c.EmaterialId).NotEmpty();
        RuleFor(c => c.BasketId).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty().WithMessage("TotalPrice  cannot be empty.")//TotalPrice boþ olmamalý 
          .GreaterThan(0).WithMessage("TotalPrice must be greater than zero."); // TotalPrice sýfýrdan büyük olmalý
        RuleFor(c => c.Quantity).NotEmpty().WithMessage("Quantity cannot be empty.") //Quantity boþ olmamalý
            .GreaterThan(0).WithMessage("Quantity must be greater than zero."); // Quantity sýfýrdan büyük olmalý;
    }
}