using Application.Features.PaymentTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PaymentTypes.Rules;

public class PaymentTypeBusinessRules : BaseBusinessRules
{
    private readonly IPaymentTypeRepository _paymentTypeRepository;
    private readonly ILocalizationService _localizationService;

    public PaymentTypeBusinessRules(IPaymentTypeRepository paymentTypeRepository, ILocalizationService localizationService)
    {
        _paymentTypeRepository = paymentTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PaymentTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PaymentTypeShouldExistWhenSelected(PaymentType? paymentType)
    {
        if (paymentType == null)
            await throwBusinessException(PaymentTypesBusinessMessages.PaymentTypeNotExists);
    }

    public async Task PaymentTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PaymentType? paymentType = await _paymentTypeRepository.GetAsync(
            predicate: pt => pt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PaymentTypeShouldExistWhenSelected(paymentType);
    }

    // iþ kuralý ödeme türü adýnýn benzersiz olup olmadýðýný kontrol etmek için
    public async Task PaymentTypeNameShouldBeUnique(string name)
    {
        PaymentType? existingPaymentType = await _paymentTypeRepository.GetAsync(
            predicate: pt => pt.Name == name,
            enableTracking: false
        );

        if (existingPaymentType != null)
        {
            await throwBusinessException(PaymentTypesBusinessMessages.PaymentTypeNameNotUnique);
        }
    }

}
