using Application.Features.BasketEmaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BasketEmaterials.Rules;

public class BasketEmaterialBusinessRules : BaseBusinessRules
{
    private readonly IBasketEmaterialRepository _basketEmaterialRepository;
    private readonly ILocalizationService _localizationService;

    public BasketEmaterialBusinessRules(IBasketEmaterialRepository basketEmaterialRepository, ILocalizationService localizationService)
    {
        _basketEmaterialRepository = basketEmaterialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BasketEmaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BasketEmaterialShouldExistWhenSelected(BasketEmaterial? basketEmaterial)
    {
        if (basketEmaterial == null)
            await throwBusinessException(BasketEmaterialsBusinessMessages.BasketEmaterialNotExists);
    }

    public async Task BasketEmaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BasketEmaterial? basketEmaterial = await _basketEmaterialRepository.GetAsync(
            predicate: be => be.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BasketEmaterialShouldExistWhenSelected(basketEmaterial);
    }
}