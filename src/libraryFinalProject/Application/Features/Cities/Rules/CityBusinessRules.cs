using Application.Features.Cities.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Cities.Rules;

public class CityBusinessRules : BaseBusinessRules
{
    private readonly ICityRepository _cityRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly ILocalizationService _localizationService;

    public CityBusinessRules(ICityRepository cityRepository, ILocalizationService localizationService,ICountryRepository countryRepository)
    {
        _cityRepository = cityRepository;
        _localizationService = localizationService;
        _countryRepository = countryRepository;

    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CitiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CityShouldExistWhenSelected(City? city)
    {
        if (city == null)
            await throwBusinessException(CitiesBusinessMessages.CityNotExists);
    }

    public async Task CityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        City? city = await _cityRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CityShouldExistWhenSelected(city);
    }

    public async Task CityNameShouldUniq(string name, CancellationToken cancellationToken)
    {
        City? city = await _cityRepository.GetAsync(
            predicate: c => c.CityName == name,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (city != null)
            await throwBusinessException(CitiesBusinessMessages.CityAlreadyExists);
    }

    public async Task CountryIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        Country? country = await _countryRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (country == null)
            await throwBusinessException(CitiesBusinessMessages.CountryNotFound);
    }
}
//City id, name benzersiz olmalý. - Ýþ kuralý
//Cityde seçilecek olan ülkenin mevcut olmasý gerekiyor. - Ýþ kuralý
