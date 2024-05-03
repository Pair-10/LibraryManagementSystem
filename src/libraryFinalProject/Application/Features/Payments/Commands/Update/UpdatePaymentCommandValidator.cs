using Application.Features.Payments.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Payments.Commands.Update;

public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
{
    private ILocalizationService _localizationService;
    public UpdatePaymentCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PaymentTypeId).NotEmpty();
        RuleFor(c => c.Desc).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.PaymentPrice).NotEmpty().GreaterThan(0).WithMessage(GetLocalized("PaymentAmountMustBe").Result);
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, PaymentsBusinessMessages.SectionName);

    }
}