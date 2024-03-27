using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Magazines;

public interface IMagazineService
{
    Task<Magazine?> GetAsync(
        Expression<Func<Magazine, bool>> predicate,
        Func<IQueryable<Magazine>, IIncludableQueryable<Magazine, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Magazine>?> GetListAsync(
        Expression<Func<Magazine, bool>>? predicate = null,
        Func<IQueryable<Magazine>, IOrderedQueryable<Magazine>>? orderBy = null,
        Func<IQueryable<Magazine>, IIncludableQueryable<Magazine, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Magazine> AddAsync(Magazine magazine);
    Task<Magazine> UpdateAsync(Magazine magazine);
    Task<Magazine> DeleteAsync(Magazine magazine, bool permanent = false);
}
