using FluentValidation;

namespace Application.Features.BasketEmaterials.Commands.Update;

public class UpdateBasketEmaterialCommandValidator : AbstractValidator<UpdateBasketEmaterialCommand>
{
    public UpdateBasketEmaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EmeterialId).NotEmpty();
        RuleFor(c => c.BasketId).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
    }
}