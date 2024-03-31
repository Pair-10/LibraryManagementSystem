using Application.Features.BasketEmaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Activities.Constants;
using Application.Features.BorrowedMaterials.Constants;

namespace Application.Features.BasketEmaterials.Rules;

public class BasketEmaterialBusinessRules : BaseBusinessRules
{
    private readonly IBasketRepository _basketRepository;//
    private readonly IEmaterialRepository _ematerialRepository;//
    private readonly IBasketEmaterialRepository _basketEmaterialRepository;
    private readonly ILocalizationService _localizationService;

    public BasketEmaterialBusinessRules(IBasketEmaterialRepository basketEmaterialRepository, ILocalizationService localizationService, IBasketRepository basketRepository, IEmaterialRepository ematerialRepository)
    {
        _basketEmaterialRepository = basketEmaterialRepository;
        _localizationService = localizationService;
        _basketRepository = basketRepository;//ctora basketrepo eklendi
        _ematerialRepository = ematerialRepository;//ctora ematerialrepo eklendi
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
    ///
     //Girilen Emateryalid deðeri mevcut deðilse hata kodu fýrlat
    public async Task BasketematerialShouldExist(Guid ematerialId)//
    {
        // Veritabanýnda belirtilen Ematerial ID deðerine sahip emateryal var mý kontrol et
        var ematerial = await _ematerialRepository.GetAsync(
            predicate: c => c.Id == ematerialId,
            enableTracking: false
        );

        // Eðer ematerial bulunamazsa, uygun hata mesajýný oluþtur ve bir istisna fýrlat
        if (ematerial == null)
        {
            await throwBusinessException(BasketEmaterialsBusinessMessages.EmaterialNotExists);//hata mesajý tanýmý
        }
    }
    //Girilen Basketid deðeri mevcut deðilse hata kodu fýrlat
    public async Task BasketEmaterialShouldExist(Guid basketId)
    {
        // Veritabanýnda belirtilen Basket ID deðerine sahip sepet var mý kontrol et
        var basket = await _basketRepository.GetAsync(
            predicate: c => c.Id == basketId,
            enableTracking: false
        );

        // Eðer user bulunamazsa, uygun hata mesajýný oluþtur ve bir istisna fýrlat
        if (basket == null)
        {
            await throwBusinessException(BasketEmaterialsBusinessMessages.BasketNotExists);//hata mesajý tanýmý
        }
    }


}