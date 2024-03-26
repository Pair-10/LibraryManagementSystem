using Application.Features.CategoryTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CategoryTypes.Rules;

public class CategoryTypeBusinessRules : BaseBusinessRules
{
    private readonly ICategoryTypeRepository _categoryTypeRepository;
    private readonly ILocalizationService _localizationService;

    public CategoryTypeBusinessRules(ICategoryTypeRepository categoryTypeRepository, ILocalizationService localizationService)
    {
        _categoryTypeRepository = categoryTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CategoryTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CategoryTypeShouldExistWhenSelected(CategoryType? categoryType)
    {
        if (categoryType == null)
            await throwBusinessException(CategoryTypesBusinessMessages.CategoryTypeNotExists);
    }

    public async Task CategoryTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CategoryType? categoryType = await _categoryTypeRepository.GetAsync(
            predicate: ct => ct.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CategoryTypeShouldExistWhenSelected(categoryType);
    }
}