using Application.Features.MaterialPublishers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Materials.Constants;
using Application.Features.Publishers.Constants;

namespace Application.Features.MaterialPublishers.Rules;

public class MaterialPublisherBusinessRules : BaseBusinessRules
{
    private readonly IMaterialPublisherRepository _materialPublisherRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMaterialRepository _materialRepository;

    public MaterialPublisherBusinessRules(IMaterialPublisherRepository materialPublisherRepository, ILocalizationService localizationService, IMaterialRepository materialRepository, IPublisherRepository publisherRepository)
    {
        _materialPublisherRepository = materialPublisherRepository;
        _localizationService = localizationService;
        _materialRepository = materialRepository;
        _publisherRepository = publisherRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialPublishersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialPublisherShouldExistWhenSelected(MaterialPublisher? materialPublisher)
    {
        if (materialPublisher == null)
            await throwBusinessException(MaterialPublishersBusinessMessages.MaterialPublisherNotExists);
    }

    public async Task MaterialPublisherIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialPublisher? materialPublisher = await _materialPublisherRepository.GetAsync(
            predicate: mp => mp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialPublisherShouldExistWhenSelected(materialPublisher);
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

    public async Task PublisherShouldExistWhenSelected(Publisher? publisher)
    {
        if (publisher == null)
            await throwBusinessException(PublishersBusinessMessages.PublisherNotExists);
    }

    public async Task PublisherIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Publisher? publisher = await _publisherRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PublisherShouldExistWhenSelected(publisher);
    }
}