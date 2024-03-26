using FluentValidation;

namespace Application.Features.Payments.Commands.Update;

public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PaymentTypeId).NotEmpty();
        RuleFor(c => c.PaymentPrice).NotEmpty();
        RuleFor(c => c.Desc).NotEmpty();
    }
}