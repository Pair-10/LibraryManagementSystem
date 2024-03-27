using FluentValidation;

namespace Application.Features.Invoices.Commands.Create;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(c => c.InvoiceDate).NotEmpty();
        RuleFor(c => c.InvoicePrice).NotEmpty();
        RuleFor(c => c.InvoiceType).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
    }
}