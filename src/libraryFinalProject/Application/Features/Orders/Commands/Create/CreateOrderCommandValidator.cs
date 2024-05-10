using FluentValidation;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.TotalPrice).NotEmpty().GreaterThan(0);
        RuleFor(c => c.Status).NotEmpty();
    }
}
