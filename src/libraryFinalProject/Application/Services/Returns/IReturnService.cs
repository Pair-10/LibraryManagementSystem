using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Returns;

public interface IReturnService
{
    Task<Return?> GetAsync(
        Expression<Func<Return, bool>> predicate,
        Func<IQueryable<Return>, IIncludableQueryable<Return, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Return>?> GetListAsync(
        Expression<Func<Return, bool>>? predicate = null,
        Func<IQueryable<Return>, IOrderedQueryable<Return>>? orderBy = null,
        Func<IQueryable<Return>, IIncludableQueryable<Return, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Return> AddAsync(Return return);
    Task<Return> UpdateAsync(Return return);
    Task<Return> DeleteAsync(Return return, bool permanent = false);
}
