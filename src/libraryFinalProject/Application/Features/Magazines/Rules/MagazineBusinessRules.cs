using Application.Features.Magazines.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Magazines.Rules;

public class MagazineBusinessRules : BaseBusinessRules
{
    private readonly IMagazineRepository _magazineRepository;
    private readonly ILocalizationService _localizationService;

    public MagazineBusinessRules(IMagazineRepository magazineRepository, ILocalizationService localizationService)
    {
        _magazineRepository = magazineRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MagazinesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MagazineShouldExistWhenSelected(Magazine? magazine)
    {
        if (magazine == null)
            await throwBusinessException(MagazinesBusinessMessages.MagazineNotExists);
    }

    public async Task MagazineIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Magazine? magazine = await _magazineRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MagazineShouldExistWhenSelected(magazine);
    }
}