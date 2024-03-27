using FluentValidation;

namespace Application.Features.PaymentTypes.Commands.Update;

public class UpdatePaymentTypeCommandValidator : AbstractValidator<UpdatePaymentTypeCommand>
{
    public UpdatePaymentTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}