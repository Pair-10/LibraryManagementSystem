using Application.Features.EmaterialInvoices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.EmaterialInvoices.Rules;

public class EmaterialInvoiceBusinessRules : BaseBusinessRules
{
    private readonly IEmaterialInvoiceRepository _ematerialInvoiceRepository;
    private readonly ILocalizationService _localizationService;

    public EmaterialInvoiceBusinessRules(IEmaterialInvoiceRepository ematerialInvoiceRepository, ILocalizationService localizationService)
    {
        _ematerialInvoiceRepository = ematerialInvoiceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EmaterialInvoicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EmaterialInvoiceShouldExistWhenSelected(EmaterialInvoice? ematerialInvoice)
    {
        if (ematerialInvoice == null)
            await throwBusinessException(EmaterialInvoicesBusinessMessages.EmaterialInvoiceNotExists);
    }

    public async Task EmaterialInvoiceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        EmaterialInvoice? ematerialInvoice = await _ematerialInvoiceRepository.GetAsync(
            predicate: ei => ei.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EmaterialInvoiceShouldExistWhenSelected(ematerialInvoice);
    }
}