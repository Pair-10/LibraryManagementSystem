using FluentValidation;

namespace Application.Features.PaymentTypes.Commands.Create;

public class CreatePaymentTypeCommandValidator : AbstractValidator<CreatePaymentTypeCommand>
{
    public CreatePaymentTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}