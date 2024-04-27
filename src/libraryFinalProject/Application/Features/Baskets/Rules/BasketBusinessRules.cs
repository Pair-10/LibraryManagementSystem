using Application.Features.Baskets.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Baskets.Rules;

public class BasketBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;//
    private readonly IBasketRepository _basketRepository;
    private readonly ILocalizationService _localizationService;

    public BasketBusinessRules(IBasketRepository basketRepository, ILocalizationService localizationService, IUserRepository userRepository)
    {
        _basketRepository = basketRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;//ctora userrepo eklendi
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BasketsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BasketShouldExistWhenSelected(Basket? basket)
    {
        if (basket == null)
            await throwBusinessException(BasketsBusinessMessages.BasketNotExists);
    }

    public async Task BasketIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Basket? basket = await _basketRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BasketShouldExistWhenSelected(basket);
    }
    ///
    //Girilen Userid de�eri mevcut de�ilse hata kodu f�rlat
    public async Task UserShouldExist(Guid userId)//
    {
        // Veritaban�nda belirtilen User ID de�erine sahip user var m� kontrol et
        var user = await _userRepository.GetAsync(
            predicate: c => c.Id == userId,
            enableTracking: false
        );

        // E�er user bulunamazsa hata mesaj�n� olu�tur ve bir istisna f�rlat
        if (user == null)
        {
            await throwBusinessException(BasketsBusinessMessages.UserNotExists);//hata mesaj� tan�m�
        }

    }

}