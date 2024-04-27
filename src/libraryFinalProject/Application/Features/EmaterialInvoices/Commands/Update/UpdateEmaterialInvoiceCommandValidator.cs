using FluentValidation;

namespace Application.Features.EmaterialInvoices.Commands.Update;

public class UpdateEmaterialInvoiceCommandValidator : AbstractValidator<UpdateEmaterialInvoiceCommand>
{
    public UpdateEmaterialInvoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EmaterialId).NotEmpty();
        RuleFor(c => c.InvoiceId).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.QuantityPrice).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty();
        RuleFor(c => c.PaymentType).NotEmpty();
    }
}