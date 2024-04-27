using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BasketEmaterials;

public interface IBasketEmaterialService
{
    Task<BasketEmaterial?> GetAsync(
        Expression<Func<BasketEmaterial, bool>> predicate,
        Func<IQueryable<BasketEmaterial>, IIncludableQueryable<BasketEmaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BasketEmaterial>?> GetListAsync(
        Expression<Func<BasketEmaterial, bool>>? predicate = null,
        Func<IQueryable<BasketEmaterial>, IOrderedQueryable<BasketEmaterial>>? orderBy = null,
        Func<IQueryable<BasketEmaterial>, IIncludableQueryable<BasketEmaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BasketEmaterial> AddAsync(BasketEmaterial basketEmaterial);
    Task<BasketEmaterial> UpdateAsync(BasketEmaterial basketEmaterial);
    Task<BasketEmaterial> DeleteAsync(BasketEmaterial basketEmaterial, bool permanent = false);
}
