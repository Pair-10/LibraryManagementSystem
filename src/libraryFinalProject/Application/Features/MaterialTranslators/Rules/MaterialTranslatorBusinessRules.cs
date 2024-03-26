using Application.Features.MaterialTranslators.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialTranslators.Rules;

public class MaterialTranslatorBusinessRules : BaseBusinessRules
{
    private readonly IMaterialTranslatorRepository _materialTranslatorRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialTranslatorBusinessRules(IMaterialTranslatorRepository materialTranslatorRepository, ILocalizationService localizationService)
    {
        _materialTranslatorRepository = materialTranslatorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialTranslatorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialTranslatorShouldExistWhenSelected(MaterialTranslator? materialTranslator)
    {
        if (materialTranslator == null)
            await throwBusinessException(MaterialTranslatorsBusinessMessages.MaterialTranslatorNotExists);
    }

    public async Task MaterialTranslatorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialTranslator? materialTranslator = await _materialTranslatorRepository.GetAsync(
            predicate: mt => mt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialTranslatorShouldExistWhenSelected(materialTranslator);
    }
}