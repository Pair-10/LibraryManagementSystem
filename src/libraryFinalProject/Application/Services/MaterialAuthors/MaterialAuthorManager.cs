using Application.Features.MaterialAuthors.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialAuthors;

public class MaterialAuthorManager : IMaterialAuthorService
{
    private readonly IMaterialAuthorRepository _materialAuthorRepository;
    private readonly MaterialAuthorBusinessRules _materialAuthorBusinessRules;

    public MaterialAuthorManager(IMaterialAuthorRepository materialAuthorRepository, MaterialAuthorBusinessRules materialAuthorBusinessRules)
    {
        _materialAuthorRepository = materialAuthorRepository;
        _materialAuthorBusinessRules = materialAuthorBusinessRules;
    }

    public async Task<MaterialAuthor?> GetAsync(
        Expression<Func<MaterialAuthor, bool>> predicate,
        Func<IQueryable<MaterialAuthor>, IIncludableQueryable<MaterialAuthor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialAuthor? materialAuthor = await _materialAuthorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialAuthor;
    }

    public async Task<IPaginate<MaterialAuthor>?> GetListAsync(
        Expression<Func<MaterialAuthor, bool>>? predicate = null,
        Func<IQueryable<MaterialAuthor>, IOrderedQueryable<MaterialAuthor>>? orderBy = null,
        Func<IQueryable<MaterialAuthor>, IIncludableQueryable<MaterialAuthor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialAuthor> materialAuthorList = await _materialAuthorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialAuthorList;
    }

    public async Task<MaterialAuthor> AddAsync(MaterialAuthor materialAuthor)
    {
        MaterialAuthor addedMaterialAuthor = await _materialAuthorRepository.AddAsync(materialAuthor);

        return addedMaterialAuthor;
    }

    public async Task<MaterialAuthor> UpdateAsync(MaterialAuthor materialAuthor)
    {
        MaterialAuthor updatedMaterialAuthor = await _materialAuthorRepository.UpdateAsync(materialAuthor);

        return updatedMaterialAuthor;
    }

    public async Task<MaterialAuthor> DeleteAsync(MaterialAuthor materialAuthor, bool permanent = false)
    {
        MaterialAuthor deletedMaterialAuthor = await _materialAuthorRepository.DeleteAsync(materialAuthor);

        return deletedMaterialAuthor;
    }
}
