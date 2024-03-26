using FluentValidation;

namespace Application.Features.EmaterialInvoices.Commands.Delete;

public class DeleteEmaterialInvoiceCommandValidator : AbstractValidator<DeleteEmaterialInvoiceCommand>
{
    public DeleteEmaterialInvoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}