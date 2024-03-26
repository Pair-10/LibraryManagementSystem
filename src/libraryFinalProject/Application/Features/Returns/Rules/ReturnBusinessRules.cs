using Application.Features.Returns.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Returns.Rules;

public class ReturnBusinessRules : BaseBusinessRules
{
    private readonly IReturnRepository _returnRepository;
    private readonly ILocalizationService _localizationService;

    public ReturnBusinessRules(IReturnRepository returnRepository, ILocalizationService localizationService)
    {
        _returnRepository = returnRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ReturnsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ReturnShouldExistWhenSelected(Return? return)
    {
        if (return == null)
            await throwBusinessException(ReturnsBusinessMessages.ReturnNotExists);
    }

    public async Task ReturnIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Return? return = await _returnRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ReturnShouldExistWhenSelected(return);
    }
}