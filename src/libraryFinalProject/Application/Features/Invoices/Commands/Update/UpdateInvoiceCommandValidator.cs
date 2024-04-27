using FluentValidation;

namespace Application.Features.Invoices.Commands.Update;

public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
{
    public UpdateInvoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.InvoiceDate).NotEmpty().Must(BeEarlierThanNow).WithMessage("Tarih boþ ve þimdiki tarihten sonraki bir tarih olamaz.");
        RuleFor(c => c.InvoicePrice).NotEmpty().GreaterThan(0).WithMessage("Girilen fiyat boþ veya sýfýrdan küçük olamaz.");
        RuleFor(c => c.InvoiceType).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
    }
    private bool BeEarlierThanNow(DateTime selectedDate)
    {
        return selectedDate < DateTime.Now;
    }
}