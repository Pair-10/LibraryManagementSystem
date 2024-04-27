using Application.Features.Districts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Districts.Rules;

public class DistrictBusinessRules : BaseBusinessRules
{
    private readonly IDistrictRepository _districtRepository;
    private readonly ICityRepository _cityRepository;
    private readonly ILocalizationService _localizationService;

    public DistrictBusinessRules(IDistrictRepository districtRepository, ILocalizationService localizationService, ICityRepository cityRepository)
    {
        _districtRepository = districtRepository;
        _localizationService = localizationService;
        _cityRepository = cityRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DistrictsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DistrictShouldExistWhenSelected(District? district)
    {
        if (district == null)
            await throwBusinessException(DistrictsBusinessMessages.DistrictNotExists);
    }

    public async Task DistrictIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        District? district = await _districtRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DistrictShouldExistWhenSelected(district);
    }

    public async Task CityShouldExist(Guid id, CancellationToken cancellationToken)
    {
        City? city = await _cityRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (city == null)
            await throwBusinessException(DistrictsBusinessMessages.CityNotFound);
    }
}
//District id benzersiz olmalý. - Ýþ kuralý.
//Districtte seçilen citynin mevcut olmasý gerekiyor. - Ýþ kuralý.