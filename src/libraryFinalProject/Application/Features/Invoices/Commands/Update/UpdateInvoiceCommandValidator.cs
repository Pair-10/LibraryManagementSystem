using FluentValidation;

namespace Application.Features.Invoices.Commands.Update;

public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
{
    public UpdateInvoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.InvoiceDate).NotEmpty().Must(BeEarlierThanNow).WithMessage("Tarih bo� ve �imdiki tarihten sonraki bir tarih olamaz.");
        RuleFor(c => c.InvoicePrice).NotEmpty().GreaterThan(0).WithMessage("Girilen fiyat bo� veya s�f�rdan k���k olamaz.");
        RuleFor(c => c.InvoiceType).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
    }
    private bool BeEarlierThanNow(DateTime selectedDate)
    {
        return selectedDate < DateTime.Now;
    }
}