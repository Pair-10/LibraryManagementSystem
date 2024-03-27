using FluentValidation;

namespace Application.Features.BasketEmaterials.Commands.Create;

public class CreateBasketEmaterialCommandValidator : AbstractValidator<CreateBasketEmaterialCommand>
{
    public CreateBasketEmaterialCommandValidator()
    {
        RuleFor(c => c.EmeterialId).NotEmpty();
        RuleFor(c => c.BasketId).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
    }
}