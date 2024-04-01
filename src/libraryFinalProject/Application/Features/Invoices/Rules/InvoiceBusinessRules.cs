using Application.Features.Invoices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Invoices.Rules;

public class InvoiceBusinessRules : BaseBusinessRules
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ILocalizationService _localizationService;

    public InvoiceBusinessRules(IInvoiceRepository invoiceRepository, ILocalizationService localizationService, IOrderRepository orderRepository)
    {
        _invoiceRepository = invoiceRepository;
        _localizationService = localizationService;
        _orderRepository = orderRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, InvoicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task InvoiceShouldExistWhenSelected(Invoice? invoice)
    {
        if (invoice == null)
            await throwBusinessException(InvoicesBusinessMessages.InvoiceNotExists);
    }

    public async Task InvoiceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Invoice? invoice = await _invoiceRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InvoiceShouldExistWhenSelected(invoice);
    }

    public async Task OrderIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetAsync(
            predicate: o => o.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (order == null)
            await throwBusinessException(InvoicesBusinessMessages.OrderNotFound);
    }
}
//Invoice id benzersiz olmalý.
//Invoice date geçmiþ bir zaman olmalý. - Validasyon.
//Invoice price sayýsal bir deðer olmalý ve sýfýrdan büyük olmalý. - Validasyon.
//Baðlý olunan orders id nin var olup olmadýðý kontrol edilmelidir. - Ýþ kuralý.