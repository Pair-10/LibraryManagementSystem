using Application.Features.MaterialPublishers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialPublishers.Rules;

public class MaterialPublisherBusinessRules : BaseBusinessRules
{
    private readonly IMaterialPublisherRepository _materialPublisherRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialPublisherBusinessRules(IMaterialPublisherRepository materialPublisherRepository, ILocalizationService localizationService)
    {
        _materialPublisherRepository = materialPublisherRepository;
        _localizationService = localizationService;
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
}