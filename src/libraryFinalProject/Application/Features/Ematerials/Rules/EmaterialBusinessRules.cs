using Application.Features.Ematerials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Ematerials.Rules;

public class EmaterialBusinessRules : BaseBusinessRules
{
    private readonly IEmaterialRepository _ematerialRepository;
    private readonly ILocalizationService _localizationService;

    public EmaterialBusinessRules(IEmaterialRepository ematerialRepository, ILocalizationService localizationService)
    {
        _ematerialRepository = ematerialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EmaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EmaterialShouldExistWhenSelected(Ematerial? ematerial)
    {
        if (ematerial == null)
            await throwBusinessException(EmaterialsBusinessMessages.EmaterialNotExists);
    }

    public async Task EmaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Ematerial? ematerial = await _ematerialRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EmaterialShouldExistWhenSelected(ematerial);
    }
}