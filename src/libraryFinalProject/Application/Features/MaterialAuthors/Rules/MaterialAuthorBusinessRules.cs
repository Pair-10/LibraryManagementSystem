using Application.Features.MaterialAuthors.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Materials.Constants;
using Application.Features.Authors.Constants;

namespace Application.Features.MaterialAuthors.Rules;

public class MaterialAuthorBusinessRules : BaseBusinessRules
{
    private readonly IMaterialAuthorRepository _materialAuthorRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly ILocalizationService _localizationService;

    public MaterialAuthorBusinessRules(IMaterialAuthorRepository materialAuthorRepository, ILocalizationService localizationService, IMaterialRepository materialRepository, IAuthorRepository authorRepository)
    {
        _materialAuthorRepository = materialAuthorRepository;
        _localizationService = localizationService;
        _materialRepository = materialRepository;
        _authorRepository = authorRepository;
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
    /**/
    public async Task MaterialShouldExistWhenSelected(Material? material)
    {
        if (material == null)
            await throwBusinessException(MaterialsBusinessMessages.MaterialNotExists);
    }

    public async Task MaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaterialShouldExistWhenSelected(material);
    }

    public async Task AuthorShouldExistWhenSelected(Author? author)
    {
        if (author == null)
            await throwBusinessException(AuthorsBusinessMessages.AuthorNotExists);
    }

    public async Task AuthorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Author? author = await _authorRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorShouldExistWhenSelected(author);
    }
}