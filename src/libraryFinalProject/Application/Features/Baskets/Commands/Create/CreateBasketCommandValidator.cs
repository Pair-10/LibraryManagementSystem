using FluentValidation;

namespace Application.Features.Baskets.Commands.Create;

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(c => c.ItemQuantity).NotEmpty().GreaterThan(0)
        .WithMessage("Item Quantity cannot be empty and must be greater than zero.");//Item Quantity bo� olmamal� ve s�f�rdan b�y�k olmal�
        RuleFor(c => c.TotalPrice).NotEmpty().GreaterThan(0)
        .WithMessage("TotalPrice  cannot be empty and must be greater than zero.");// TotalPrice s�f�rdan b�y�k olmal�
        RuleFor(c => c.UserId).NotEmpty();
    }
}