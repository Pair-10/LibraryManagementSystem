using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserActivities;

public interface IUserActivityService
{
    Task<UserActivity?> GetAsync(
        Expression<Func<UserActivity, bool>> predicate,
        Func<IQueryable<UserActivity>, IIncludableQueryable<UserActivity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserActivity>?> GetListAsync(
        Expression<Func<UserActivity, bool>>? predicate = null,
        Func<IQueryable<UserActivity>, IOrderedQueryable<UserActivity>>? orderBy = null,
        Func<IQueryable<UserActivity>, IIncludableQueryable<UserActivity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserActivity> AddAsync(UserActivity userActivity);
    Task<UserActivity> UpdateAsync(UserActivity userActivity);
    Task<UserActivity> DeleteAsync(UserActivity userActivity, bool permanent = false);
}
