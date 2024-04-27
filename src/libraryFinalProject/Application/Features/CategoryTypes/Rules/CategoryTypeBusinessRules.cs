using Application.Features.CategoryTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.MaterialTypes.Rules;
using Application.Features.MaterialTypes.Constants;

namespace Application.Features.CategoryTypes.Rules;

public class CategoryTypeBusinessRules : BaseBusinessRules
{
    private readonly ICategoryTypeRepository _categoryTypeRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly IMaterialTypeRepository _materialTypeRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILocalizationService _localizationService;

    public CategoryTypeBusinessRules(ICategoryTypeRepository categoryTypeRepository, ILocalizationService localizationService, IMaterialRepository materialRepository, IMaterialTypeRepository materialTypeRepository, ICategoryRepository categoryRepository)
    {
        _categoryTypeRepository = categoryTypeRepository;
        _localizationService = localizationService;
        _materialRepository = materialRepository;
        _materialTypeRepository = materialTypeRepository;
        _categoryRepository = categoryRepository;
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

    public async Task MaterialIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );
        if (material == null)
            await throwBusinessException(CategoryTypesBusinessMessages.MaterialNoExists);
    }

    public async Task MaterialTypeIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        MaterialType? materialType = await _materialTypeRepository.GetAsync(
            predicate: mt => mt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );
        if (materialType == null)
            await throwBusinessException(MaterialTypesBusinessMessages.MaterialTypeNotExists);
    }

    public async Task CategoryIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );
        if (category != null)
            await throwBusinessException(CategoryTypesBusinessMessages.CategoryNoExists);
    }

}
//CategoryType ýn içinde yazýlacak olan materyal, tür ve kategorilerin mevcut olmasý gerekli. - Ýþ kuralý
//CategorType id benzersiz olmalý. - Ýþ kuralý.