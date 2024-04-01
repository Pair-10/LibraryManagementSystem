using FluentValidation;

namespace Application.Features.Baskets.Commands.Create;

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketCommandValidator()
    {
     
        RuleFor(c => c.ItemQuantity).NotEmpty()
           .WithMessage("ItemQuantity cannot be empty.") //ItemQuantity bo� olmamal�
           .GreaterThan(0).WithMessage("ItemQuantity must be greater than zero."); // ItemQuantity s�f�rdan b�y�k olmal�
        RuleFor(c => c.TotalPrice).NotEmpty()
           .WithMessage("TotalPrice  cannot be empty.")//TotalPrice bo� olmamal� 
         .GreaterThan(0).WithMessage("TotalPrice must be greater than zero."); // TotalPrice s�f�rdan b�y�k olmal�
        RuleFor(c => c.UserId).NotEmpty();
    }
}