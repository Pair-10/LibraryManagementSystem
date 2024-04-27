using Application.Features.Countries.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Countries.Rules;

public class CountryBusinessRules : BaseBusinessRules
{
    private readonly ICountryRepository _countryRepository;
    private readonly ILocalizationService _localizationService;

    public CountryBusinessRules(ICountryRepository countryRepository, ILocalizationService localizationService)
    {
        _countryRepository = countryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CountriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CountryShouldExistWhenSelected(Country? country)
    {
        if (country == null)
            await throwBusinessException(CountriesBusinessMessages.CountryNotExists);
    }

    public async Task CountryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Country? country = await _countryRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CountryShouldExistWhenSelected(country);
    }

    public async Task CountryNameShouldUniq(string name, CancellationToken cancellationToken)
    {
        Country? country = await _countryRepository.GetAsync(
            predicate: c => c.CountryName == name,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (country != null)
            await throwBusinessException(CountriesBusinessMessages.CountryNameAlreadyExists);
    }
}
//Country id ve countryname benzersiz olmasý gerekiyor. - Ýþ kuralý.
//Countryname alaný belli bir karakterden fazla girilemez. - Validasyon.