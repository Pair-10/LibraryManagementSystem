using Application.Features.Invoices.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Invoices.Commands.Create;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    private ILocalizationService _localizationService;
    public CreateInvoiceCommandValidator(ILocalizationService localizationService)
    {
        RuleFor(c => c.InvoiceDate).NotEmpty().Must(BeEarlierThanNow).WithMessage(GetLocalized("InvalidInvoiceDateFormat").Result);
        RuleFor(c => c.InvoicePrice).NotEmpty().GreaterThan(0);
        RuleFor(c => c.InvoiceType).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        _localizationService = localizationService;
    }
    private bool BeEarlierThanNow(DateTime selectedDate)
    {
        return selectedDate < DateTime.Now;
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, InvoicesBusinessMessages.SectionName);

    }
}