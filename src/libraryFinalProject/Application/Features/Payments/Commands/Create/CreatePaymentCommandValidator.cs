using FluentValidation;
using System.Data;

namespace Application.Features.Payments.Commands.Create;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PaymentTypeId).NotEmpty();
        RuleFor(c => c.PaymentPrice).NotEmpty().GreaterThan(0).WithMessage("Payment amount must be greater than zero");
                                                                           //Ödeme tutarý sýfýrdan büyük olmalýdýr

        RuleFor(c => c.Desc).NotEmpty().MinimumLength(2).MaximumLength(70);
    }
}
