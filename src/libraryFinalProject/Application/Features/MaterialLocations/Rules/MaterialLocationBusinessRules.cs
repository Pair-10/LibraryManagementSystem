using Application.Features.MaterialLocations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Materials.Constants;
using Application.Features.Publishers.Constants;
using Application.Features.Locations.Constants;

namespace Application.Features.MaterialLocations.Rules;

public class MaterialLocationBusinessRules : BaseBusinessRules
{
    private readonly IMaterialLocationRepository _materialLocationRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialLocationBusinessRules(IMaterialLocationRepository materialLocationRepository, ILocalizationService localizationService, IMaterialRepository materialRepository, ILocationRepository locationRepository)
    {
        _materialLocationRepository = materialLocationRepository;
        _localizationService = localizationService;
        _materialRepository = materialRepository;
        _locationRepository = locationRepository;
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

    public async Task MaterialShouldExistWhenSelected(Material? material)
    {
        if (material == null)
            await throwBusinessException(MaterialsBusinessMessages.MaterialNotExists);
    }

    public async Task MaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialShouldExistWhenSelected(material);
    }
    public async Task LocationShouldExistWhenSelected(Location? location)
    {
        if (location == null)
            await throwBusinessException(LocationsBusinessMessages.LocationNotExists);
    }

    public async Task LocationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Location? location = await _locationRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LocationShouldExistWhenSelected(location);
    }
}