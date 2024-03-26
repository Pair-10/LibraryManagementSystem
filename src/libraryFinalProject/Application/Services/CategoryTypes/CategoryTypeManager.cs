using Application.Features.CategoryTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryTypes;

public class CategoryTypeManager : ICategoryTypeService
{
    private readonly ICategoryTypeRepository _categoryTypeRepository;
    private readonly CategoryTypeBusinessRules _categoryTypeBusinessRules;

    public CategoryTypeManager(ICategoryTypeRepository categoryTypeRepository, CategoryTypeBusinessRules categoryTypeBusinessRules)
    {
        _categoryTypeRepository = categoryTypeRepository;
        _categoryTypeBusinessRules = categoryTypeBusinessRules;
    }

    public async Task<CategoryType?> GetAsync(
        Expression<Func<CategoryType, bool>> predicate,
        Func<IQueryable<CategoryType>, IIncludableQueryable<CategoryType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CategoryType? categoryType = await _categoryTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return categoryType;
    }

    public async Task<IPaginate<CategoryType>?> GetListAsync(
        Expression<Func<CategoryType, bool>>? predicate = null,
        Func<IQueryable<CategoryType>, IOrderedQueryable<CategoryType>>? orderBy = null,
        Func<IQueryable<CategoryType>, IIncludableQueryable<CategoryType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CategoryType> categoryTypeList = await _categoryTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return categoryTypeList;
    }

    public async Task<CategoryType> AddAsync(CategoryType categoryType)
    {
        CategoryType addedCategoryType = await _categoryTypeRepository.AddAsync(categoryType);

        return addedCategoryType;
    }

    public async Task<CategoryType> UpdateAsync(CategoryType categoryType)
    {
        CategoryType updatedCategoryType = await _categoryTypeRepository.UpdateAsync(categoryType);

        return updatedCategoryType;
    }

    public async Task<CategoryType> DeleteAsync(CategoryType categoryType, bool permanent = false)
    {
        CategoryType deletedCategoryType = await _categoryTypeRepository.DeleteAsync(categoryType);

        return deletedCategoryType;
    }
}
