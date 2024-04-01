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
    //Girilen Userid deðeri mevcut deðilse hata kodu fýrlat
    public async Task UserShouldExist(Guid userId)//
    {
        // Veritabanýnda belirtilen User ID deðerine sahip user var mý kontrol et
        var user = await _userRepository.GetAsync(
            predicate: c => c.Id == userId,
            enableTracking: false
        );

        // Eðer user bulunamazsa hata mesajýný oluþtur ve bir istisna fýrlat
        if (user == null)
        {
            await throwBusinessException(BasketsBusinessMessages.UserNotExists);//hata mesajý tanýmý
        }

    }

}