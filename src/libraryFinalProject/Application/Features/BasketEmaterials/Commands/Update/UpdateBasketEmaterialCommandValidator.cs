using FluentValidation;

namespace Application.Features.BasketEmaterials.Commands.Update;

public class UpdateBasketEmaterialCommandValidator : AbstractValidator<UpdateBasketEmaterialCommand>
{
    public UpdateBasketEmaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EmaterialId).NotEmpty();
        RuleFor(c => c.BasketId).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty().WithMessage("TotalPrice  cannot be empty.")//TotalPrice bo� olmamal� 
           .GreaterThan(0).WithMessage("TotalPrice must be greater than zero."); // TotalPrice s�f�rdan b�y�k olmal�
        RuleFor(c => c.Quantity).NotEmpty().WithMessage("Quantity cannot be empty.") //Quantity bo� olmamal�
            .GreaterThan(0).WithMessage("Quantity must be greater than zero."); // Quantity s�f�rdan b�y�k olmal�;
    }
}