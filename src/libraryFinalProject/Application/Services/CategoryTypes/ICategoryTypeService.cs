using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryTypes;

public interface ICategoryTypeService
{
    Task<CategoryType?> GetAsync(
        Expression<Func<CategoryType, bool>> predicate,
        Func<IQueryable<CategoryType>, IIncludableQueryable<CategoryType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CategoryType>?> GetListAsync(
        Expression<Func<CategoryType, bool>>? predicate = null,
        Func<IQueryable<CategoryType>, IOrderedQueryable<CategoryType>>? orderBy = null,
        Func<IQueryable<CategoryType>, IIncludableQueryable<CategoryType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CategoryType> AddAsync(CategoryType categoryType);
    Task<CategoryType> UpdateAsync(CategoryType categoryType);
    Task<CategoryType> DeleteAsync(CategoryType categoryType, bool permanent = false);
}
