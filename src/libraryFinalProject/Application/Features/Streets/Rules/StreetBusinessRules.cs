using Application.Features.Districts.Constants;
using Application.Features.Streets.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Streets.Rules;

public class StreetBusinessRules : BaseBusinessRules
{
    private readonly IStreetRepository _streetRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IDistrictRepository _districtRepository;

    public StreetBusinessRules(IStreetRepository streetRepository, ILocalizationService localizationService, IDistrictRepository districtRepository)
    {
        _streetRepository = streetRepository;
        _localizationService = localizationService;
        _districtRepository = districtRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StreetsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StreetShouldExistWhenSelected(Street? street)
    {
        if (street == null)
            await throwBusinessException(StreetsBusinessMessages.StreetNotExists);
    }

    public async Task StreetIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Street? street = await _streetRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StreetShouldExistWhenSelected(street);
    }

    public async Task DistrictShouldExist(Guid id, CancellationToken cancellationToken)
    {
        District? district = await _districtRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (district == null)
            await throwBusinessException(DistrictsBusinessMessages.DistrictNotExists);
    }
}