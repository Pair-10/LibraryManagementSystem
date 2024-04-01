using Application.Features.Magazines.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Categories.Constants;

namespace Application.Features.Magazines.Rules;

public class MagazineBusinessRules : BaseBusinessRules
{
    private readonly IMagazineRepository _magazineRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILocalizationService _localizationService;

    public MagazineBusinessRules(IMagazineRepository magazineRepository, ILocalizationService localizationService, ICategoryRepository categoryRepository)
    {
        _magazineRepository = magazineRepository;
        _localizationService = localizationService;
        _categoryRepository = categoryRepository;
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

    /****************New Section***********/
    public async Task CheckIfMagazineISSNAlreadyExists(Magazine? magazine)
    {
        if (magazine != null)
            await throwBusinessException(MagazinesBusinessMessages.CheckIfMagazineISSNAlreadyExists);
    }

    public async Task MagazineISSNShouldExistWhenSelected(string ISSN, CancellationToken cancellationToken)
    {
        Magazine? magazine = await _magazineRepository.GetAsync(
            predicate: m => m.ISSN == ISSN,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CheckIfMagazineISSNAlreadyExists(magazine);
    }

    public async Task CategoryShouldExistWhenSelected(Category? category)
    {
        if (category == null)
            await throwBusinessException(CategoriesBusinessMessages.CategoryNotExists);
    }

    public async Task CategoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CategoryShouldExistWhenSelected(category);
    }
}