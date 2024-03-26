using FluentValidation;

namespace Application.Features.BasketEmaterials.Commands.Delete;

public class DeleteBasketEmaterialCommandValidator : AbstractValidator<DeleteBasketEmaterialCommand>
{
    public DeleteBasketEmaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}