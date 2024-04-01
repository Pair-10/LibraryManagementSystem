using FluentValidation;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.TotalPrice).NotEmpty().GreaterThan(0)
        .WithMessage("The total price must be greater than zero.");
                     //Toplam fiyat sýfýrdan büyük olmalýdýr.

        RuleFor(c => c.Status).NotEmpty().WithMessage("Invalid order status.");
                                                    // Geçersiz sipariþ durumu.
    }
}
