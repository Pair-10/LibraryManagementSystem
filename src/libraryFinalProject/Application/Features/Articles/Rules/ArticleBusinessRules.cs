using Application.Features.Articles.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Articles.Rules;

public class ArticleBusinessRules : BaseBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;//
    private readonly IArticleRepository _articleRepository;
    private readonly ILocalizationService _localizationService;
    public ArticleBusinessRules(IArticleRepository articleRepository, ILocalizationService localizationService, ICategoryRepository categoryRepository)
    {

        _articleRepository = articleRepository;
        _localizationService = localizationService;
        _categoryRepository = categoryRepository;//ctora categoryrepo eklendi
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ArticlesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ArticleShouldExistWhenSelected(Article? article)
    {
        if (article == null)
            await throwBusinessException(ArticlesBusinessMessages.ArticleNotExists);
    }

    public async Task ArticleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Article? article = await _articleRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ArticleShouldExistWhenSelected(article);
    }

    public async Task CategoryShouldExist(Guid categoryId)//
    {//
        // Kategoriye �zg� bir GUID belirle //
        Guid specificCategoryId = new Guid("2bf7b236-4838-4238-2634-08dc50278ac8");//

        // Veritaban�nda belirtilen Category ID de�erine sahip kategori ve istedi�im guid e�it mi kontrol et
        var category = await _categoryRepository.GetAsync(//
            predicate: c => c.Id == categoryId && c.Id == specificCategoryId,//
            enableTracking: false//
        );//

        // E�er kategori bulunamazsa hata mesaj�n� olu�tur ev bir istisna f�rlat//
        if (category == null)//
        {//
            await throwBusinessException(ArticlesBusinessMessages.CategoryNotExists);//
        }//
    }//

}