using FluentValidation;

namespace Application.Features.PaymentTypes.Commands.Delete;

public class DeletePaymentTypeCommandValidator : AbstractValidator<DeletePaymentTypeCommand>
{
    public DeletePaymentTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}