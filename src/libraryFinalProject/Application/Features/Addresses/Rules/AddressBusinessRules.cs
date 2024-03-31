using Application.Features.Addresses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Addresses.Rules;

public class AddressBusinessRules : BaseBusinessRules
{
    private readonly IStreetRepository _streetRepository;//
    private readonly IAddressRepository _addressRepository;
    private readonly ILocalizationService _localizationService;

    public AddressBusinessRules(IAddressRepository addressRepository, ILocalizationService localizationService, IStreetRepository streetRepository)
    {
        _addressRepository = addressRepository;
        _localizationService = localizationService;
        _streetRepository = streetRepository;//ctora streetrepo eklendi
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AddressesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AddressShouldExistWhenSelected(Address? address)
    {
        if (address == null)
            await throwBusinessException(AddressesBusinessMessages.AddressNotExists);
    }

    public async Task AddressIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Address? address = await _addressRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AddressShouldExistWhenSelected(address);
    }
    ////
    // Girilen StreetId deðeri mevcut deðilse hata kodu fýrlat
    public async Task StreetShouldExist(Guid streetId)
    {
        // Veritabanýnda belirtilen Street Id deðerine sahip street var mý kontrol et
        var street = await _streetRepository.GetAsync(
            predicate: c => c.Id == streetId,
            enableTracking: false
        );

        // Eðer kategori bulunamazsa, uygun hata mesajýný oluþtur ve bir istisna fýrlat
        if (street == null)
        {
            await throwBusinessException(AddressesBusinessMessages.StreetNotExists);//hata mesajý tanýmý
        }
    }
    
}