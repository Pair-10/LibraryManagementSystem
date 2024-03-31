using FluentValidation;

namespace Application.Features.Baskets.Commands.Create;

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(c => c.ItemQuantity).NotEmpty().GreaterThan(0)
        .WithMessage("Item Quantity cannot be empty and must be greater than zero.");//Item Quantity boþ olmamalý ve sýfýrdan büyük olmalý
        RuleFor(c => c.TotalPrice).NotEmpty().GreaterThan(0)
        .WithMessage("TotalPrice  cannot be empty and must be greater than zero.");// TotalPrice sýfýrdan büyük olmalý
        RuleFor(c => c.UserId).NotEmpty();
    }
}