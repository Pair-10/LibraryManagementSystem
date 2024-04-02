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
     //Girilen Emateryalid de�eri mevcut de�ilse hata kodu f�rlat
    public async Task BasketematerialShouldExist(Guid ematerialId)//
    {
        // Veritaban�nda belirtilen Ematerial ID de�erine sahip emateryal var m� kontrol et
        var ematerial = await _ematerialRepository.GetAsync(
            predicate: c => c.Id == ematerialId,
            enableTracking: false
        );

        // E�er ematerial bulunamazsa, uygun hata mesaj�n� olu�tur ve bir istisna f�rlat
        if (ematerial == null)
        {
            await throwBusinessException(BasketEmaterialsBusinessMessages.EmaterialNotExists);//hata mesaj� tan�m�
        }
    }
    //Girilen Basketid de�eri mevcut de�ilse hata kodu f�rlat
    public async Task BasketEmaterialShouldExist(Guid basketId)
    {
        // Veritaban�nda belirtilen Basket ID de�erine sahip sepet var m� kontrol et
        var basket = await _basketRepository.GetAsync(
            predicate: c => c.Id == basketId,
            enableTracking: false
        );

        // E�er user bulunamazsa, uygun hata mesaj�n� olu�tur ve bir istisna f�rlat
        if (basket == null)
        {
            await throwBusinessException(BasketEmaterialsBusinessMessages.BasketNotExists);//hata mesaj� tan�m�
        }
    }


}