using FluentValidation;

namespace Application.Features.Baskets.Commands.Create;

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(c => c.ItemQuantity).NotEmpty().WithMessage("Item Quantity cannot be empty.") // Item Quantity boþ olmamalý
            .GreaterThan(0).WithMessage("Item Quantity must be greater than zero."); // Item Quantity sýfýrdan büyük olmalý
        RuleFor(c => c.TotalPrice).NotEmpty().WithMessage("TotalPrice  cannot be empty.") //TotalPrice boþ olmamalý 
         .GreaterThan(0).WithMessage("TotalPrice must be greater than zero."); // TotalPrice sýfýrdan büyük olmalý
        RuleFor(c => c.UserId).NotEmpty();
    }
}