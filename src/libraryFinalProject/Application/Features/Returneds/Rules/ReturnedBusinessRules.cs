using Application.Features.Returneds.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Returneds.Rules;

public class ReturnedBusinessRules : BaseBusinessRules
{
    private readonly IReturnedRepository _returnedRepository;
    private readonly ILocalizationService _localizationService;

    public ReturnedBusinessRules(IReturnedRepository returnedRepository, ILocalizationService localizationService)
    {
        _returnedRepository = returnedRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ReturnedsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ReturnedShouldExistWhenSelected(Returned? returned)
    {
        if (returned == null)
            await throwBusinessException(ReturnedsBusinessMessages.ReturnedNotExists);
    }

    public async Task ReturnedIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Returned? returned = await _returnedRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ReturnedShouldExistWhenSelected(returned);
    }
}