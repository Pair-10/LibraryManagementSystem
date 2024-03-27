using Application.Features.MaterialTranslators.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialTranslators;

public class MaterialTranslatorManager : IMaterialTranslatorService
{
    private readonly IMaterialTranslatorRepository _materialTranslatorRepository;
    private readonly MaterialTranslatorBusinessRules _materialTranslatorBusinessRules;

    public MaterialTranslatorManager(IMaterialTranslatorRepository materialTranslatorRepository, MaterialTranslatorBusinessRules materialTranslatorBusinessRules)
    {
        _materialTranslatorRepository = materialTranslatorRepository;
        _materialTranslatorBusinessRules = materialTranslatorBusinessRules;
    }

    public async Task<MaterialTranslator?> GetAsync(
        Expression<Func<MaterialTranslator, bool>> predicate,
        Func<IQueryable<MaterialTranslator>, IIncludableQueryable<MaterialTranslator, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialTranslator? materialTranslator = await _materialTranslatorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialTranslator;
    }

    public async Task<IPaginate<MaterialTranslator>?> GetListAsync(
        Expression<Func<MaterialTranslator, bool>>? predicate = null,
        Func<IQueryable<MaterialTranslator>, IOrderedQueryable<MaterialTranslator>>? orderBy = null,
        Func<IQueryable<MaterialTranslator>, IIncludableQueryable<MaterialTranslator, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialTranslator> materialTranslatorList = await _materialTranslatorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialTranslatorList;
    }

    public async Task<MaterialTranslator> AddAsync(MaterialTranslator materialTranslator)
    {
        MaterialTranslator addedMaterialTranslator = await _materialTranslatorRepository.AddAsync(materialTranslator);

        return addedMaterialTranslator;
    }

    public async Task<MaterialTranslator> UpdateAsync(MaterialTranslator materialTranslator)
    {
        MaterialTranslator updatedMaterialTranslator = await _materialTranslatorRepository.UpdateAsync(materialTranslator);

        return updatedMaterialTranslator;
    }

    public async Task<MaterialTranslator> DeleteAsync(MaterialTranslator materialTranslator, bool permanent = false)
    {
        MaterialTranslator deletedMaterialTranslator = await _materialTranslatorRepository.DeleteAsync(materialTranslator);

        return deletedMaterialTranslator;
    }
}
