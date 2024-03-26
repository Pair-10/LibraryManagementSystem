using Application.Features.OrderEMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.OrderEMaterials.Rules;

public class OrderEMaterialBusinessRules : BaseBusinessRules
{
    private readonly IOrderEMaterialRepository _orderEMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public OrderEMaterialBusinessRules(IOrderEMaterialRepository orderEMaterialRepository, ILocalizationService localizationService)
    {
        _orderEMaterialRepository = orderEMaterialRepository;
        _localizationService = localizationService;
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
}