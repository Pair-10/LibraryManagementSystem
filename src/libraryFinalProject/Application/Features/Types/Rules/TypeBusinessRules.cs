using Application.Features.Types.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Types.Rules;

public class TypeBusinessRules : BaseBusinessRules
{
    private readonly ITypeRepository _typeRepository;
    private readonly ILocalizationService _localizationService;

    public TypeBusinessRules(ITypeRepository typeRepository, ILocalizationService localizationService)
    {
        _typeRepository = typeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TypeShouldExistWhenSelected(Type? type)
    {
        if (type == null)
            await throwBusinessException(TypesBusinessMessages.TypeNotExists);
    }

    public async Task TypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Type? type = await _typeRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TypeShouldExistWhenSelected(type);
    }
}