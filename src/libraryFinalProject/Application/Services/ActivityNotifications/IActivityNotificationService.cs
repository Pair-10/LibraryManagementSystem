using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ActivityNotifications;

public interface IActivityNotificationService
{
    Task<ActivityNotification?> GetAsync(
        Expression<Func<ActivityNotification, bool>> predicate,
        Func<IQueryable<ActivityNotification>, IIncludableQueryable<ActivityNotification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ActivityNotification>?> GetListAsync(
        Expression<Func<ActivityNotification, bool>>? predicate = null,
        Func<IQueryable<ActivityNotification>, IOrderedQueryable<ActivityNotification>>? orderBy = null,
        Func<IQueryable<ActivityNotification>, IIncludableQueryable<ActivityNotification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ActivityNotification> AddAsync(ActivityNotification activityNotification);
    Task<ActivityNotification> UpdateAsync(ActivityNotification activityNotification);
    Task<ActivityNotification> DeleteAsync(ActivityNotification activityNotification, bool permanent = false);
}
