using Application.Features.Articles.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Articles.Rules;

public class ArticleBusinessRules : BaseBusinessRules
{
    private readonly IArticleRepository _articleRepository;
    private readonly ILocalizationService _localizationService;

    public ArticleBusinessRules(IArticleRepository articleRepository, ILocalizationService localizationService)
    {
        _articleRepository = articleRepository;
        _localizationService = localizationService;
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
}