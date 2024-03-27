using Application.Features.MaterialAuthors.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaterialAuthors.Rules;

public class MaterialAuthorBusinessRules : BaseBusinessRules
{
    private readonly IMaterialAuthorRepository _materialAuthorRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialAuthorBusinessRules(IMaterialAuthorRepository materialAuthorRepository, ILocalizationService localizationService)
    {
        _materialAuthorRepository = materialAuthorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaterialAuthorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaterialAuthorShouldExistWhenSelected(MaterialAuthor? materialAuthor)
    {
        if (materialAuthor == null)
            await throwBusinessException(MaterialAuthorsBusinessMessages.MaterialAuthorNotExists);
    }

    public async Task MaterialAuthorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MaterialAuthor? materialAuthor = await _materialAuthorRepository.GetAsync(
            predicate: ma => ma.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialAuthorShouldExistWhenSelected(materialAuthor);
    }
}