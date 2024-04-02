using Application.Features.OrderEMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Orders.Constants;
using Application.Features.Ematerials.Constants;

namespace Application.Features.OrderEMaterials.Rules;

public class OrderEMaterialBusinessRules : BaseBusinessRules
{
    private readonly IOrderEMaterialRepository _orderEMaterialRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IEmaterialRepository _ematerialRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderEMaterialBusinessRules(IOrderEMaterialRepository orderEMaterialRepository, ILocalizationService localizationService, IEmaterialRepository ematerialRepository, IOrderRepository orderRepository)
    {
        _orderEMaterialRepository = orderEMaterialRepository;
        _localizationService = localizationService;
        _ematerialRepository = ematerialRepository;
        _orderRepository = orderRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OrderEMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OrderEMaterialShouldExistWhenSelected(OrderEMaterial? orderEMaterial)
    {
        if (orderEMaterial == null)
            await throwBusinessException(OrderEMaterialsBusinessMessages.OrderEMaterialNotExists);
    }

    public async Task OrderEMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        OrderEMaterial? orderEMaterial = await _orderEMaterialRepository.GetAsync(
            predicate: oem => oem.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderEMaterialShouldExistWhenSelected(orderEMaterial);
    }
    // iþ kuralý
    public async Task EMaterialRelationshipsShouldBeValid(Guid eMaterialId)
    {
        Ematerial? ematerial = await _ematerialRepository.GetAsync(
            predicate: em => em.Id == eMaterialId,
            enableTracking: false
        );
        if (ematerial == null )
        {
            await throwBusinessException(EmaterialsBusinessMessages.EmaterialNotExists);
        }
    }

    public async Task OrderRelationshipsShouldBeValid(Guid orderId)
    {
        Order? order = await _orderRepository.GetAsync(
            predicate: o => o.Id == orderId,
            enableTracking: false
        );
        if ( order == null)
        {
            await throwBusinessException(OrdersBusinessMessages.OrderNotExists);
        }
    }
}

