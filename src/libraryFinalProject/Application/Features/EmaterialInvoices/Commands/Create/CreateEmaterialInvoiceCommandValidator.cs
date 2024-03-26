using FluentValidation;

namespace Application.Features.EmaterialInvoices.Commands.Create;

public class CreateEmaterialInvoiceCommandValidator : AbstractValidator<CreateEmaterialInvoiceCommand>
{
    public CreateEmaterialInvoiceCommandValidator()
    {
        RuleFor(c => c.EmaterialId).NotEmpty();
        RuleFor(c => c.InvoiceId).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.QuantityPrice).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty();
        RuleFor(c => c.PaymentType).NotEmpty();
    }
}