using FluentValidation;

namespace Application.Features.Payments.Commands.Create;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PaymentTypeId).NotEmpty();
        RuleFor(c => c.PaymentPrice).NotEmpty();
        RuleFor(c => c.Desc).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
    }
}