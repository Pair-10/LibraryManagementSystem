using Application.Features.MaterialTranslators.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Materials.Constants;
using Application.Features.Translators.Constants;

namespace Application.Features.MaterialTranslators.Rules;

public class MaterialTranslatorBusinessRules : BaseBusinessRules
{
    private readonly IMaterialTranslatorRepository _materialTranslatorRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly ITranslatorRepository _translatorRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialTranslatorBusinessRules(IMaterialTranslatorRepository materialTranslatorRepository, ILocalizationService localizationService, IMaterialRepository materialRepository, ITranslatorRepository translatorRepository)
    {
        _materialTranslatorRepository = materialTranslatorRepository;
        _localizationService = localizationService;
        _materialRepository = materialRepository;
        _translatorRepository = translatorRepository;
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

    public async Task TranslatorShouldExistWhenSelected(Translator? translator)
    {
        if (translator == null)
            await throwBusinessException(TranslatorsBusinessMessages.TranslatorNotExists);
    }

    public async Task TranslatorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Translator? translator = await _translatorRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TranslatorShouldExistWhenSelected(translator);
    }
}