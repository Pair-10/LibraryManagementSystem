using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Returneds;

public interface IReturnedService
{
    Task<Returned?> GetAsync(
        Expression<Func<Returned, bool>> predicate,
        Func<IQueryable<Returned>, IIncludableQueryable<Returned, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Returned>?> GetListAsync(
        Expression<Func<Returned, bool>>? predicate = null,
        Func<IQueryable<Returned>, IOrderedQueryable<Returned>>? orderBy = null,
        Func<IQueryable<Returned>, IIncludableQueryable<Returned, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Returned> AddAsync(Returned returned);
    Task<Returned> UpdateAsync(Returned returned);
    Task<Returned> DeleteAsync(Returned returned, bool permanent = false);
}
