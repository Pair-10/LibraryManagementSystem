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
    private readonly IEmaterialRepository _ematerialRepository;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ILocalizationService _localizationService;

    public EmaterialInvoiceBusinessRules(IEmaterialInvoiceRepository ematerialInvoiceRepository, ILocalizationService localizationService, IEmaterialRepository ematerialRepository, IInvoiceRepository invoiceRepository)
    {
        _ematerialInvoiceRepository = ematerialInvoiceRepository;
        _localizationService = localizationService;
        _ematerialRepository = ematerialRepository;
        _invoiceRepository = invoiceRepository;
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

    public async Task EmaterialIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        Ematerial? ematerial = await _ematerialRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (ematerial == null)
            await throwBusinessException(EmaterialInvoicesBusinessMessages.EmaterialNotFound);
    }

    public async Task InvoiceIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        Invoice? invoice = await _invoiceRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (invoice == null)
            await throwBusinessException(EmaterialInvoicesBusinessMessages.InvoiceNotFound);
    }
}
//EmaterialInvoice id benzersiz olmalý. - Ýþ kuralý.
//Eklenen invoice id ve emateryal id, invoice ve emateryal tablolarýnda mevcut olmalý. - Ýþ kuralý.
//--- PaymentType,totalprice invoice üzerinden, quantityprice ematerial üzerinden geliyor kaldýrýlmalý. ---
