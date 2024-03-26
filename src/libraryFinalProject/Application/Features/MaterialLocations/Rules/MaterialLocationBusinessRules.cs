using Application.Features.MaterialLocations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialLocations.Rules;

public class MaterialLocationBusinessRules : BaseBusinessRules
{
    private readonly IMaterialLocationRepository _materialLocationRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialLocationBusinessRules(IMaterialLocationRepository materialLocationRepository, ILocalizationService localizationService)
    {
        _materialLocationRepository = materialLocationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialLocationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialLocationShouldExistWhenSelected(MaterialLocation? materialLocation)
    {
        if (materialLocation == null)
            await throwBusinessException(MaterialLocationsBusinessMessages.MaterialLocationNotExists);
    }

    public async Task MaterialLocationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialLocation? materialLocation = await _materialLocationRepository.GetAsync(
            predicate: ml => ml.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialLocationShouldExistWhenSelected(materialLocation);
    }
}