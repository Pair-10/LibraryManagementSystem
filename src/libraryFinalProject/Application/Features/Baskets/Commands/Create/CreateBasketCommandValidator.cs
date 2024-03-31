using FluentValidation;

namespace Application.Features.Baskets.Commands.Create;

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(c => c.ItemQuantity).NotEmpty().WithMessage("Item Quantity cannot be empty.") // Item Quantity bo� olmamal�
            .GreaterThan(0).WithMessage("Item Quantity must be greater than zero."); // Item Quantity s�f�rdan b�y�k olmal�
        RuleFor(c => c.TotalPrice).NotEmpty().WithMessage("TotalPrice  cannot be empty.") //TotalPrice bo� olmamal� 
         .GreaterThan(0).WithMessage("TotalPrice must be greater than zero."); // TotalPrice s�f�rdan b�y�k olmal�
        RuleFor(c => c.UserId).NotEmpty();
    }
}