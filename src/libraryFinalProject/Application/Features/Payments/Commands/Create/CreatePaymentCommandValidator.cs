using Application.Features.Payments.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Payments.Commands.Create;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    private ILocalizationService _localizationService;
    public CreatePaymentCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PaymentTypeId).NotEmpty();
        RuleFor(c => c.PaymentPrice).NotEmpty().GreaterThan(0).WithMessage(GetLocalized("PaymentAmountMustBe").Result);


        RuleFor(c => c.Desc).NotEmpty().MinimumLength(2).MaximumLength(70);
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, PaymentsBusinessMessages.SectionName);

    }
}
