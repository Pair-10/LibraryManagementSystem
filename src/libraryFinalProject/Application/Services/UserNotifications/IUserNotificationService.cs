using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserNotifications;

public interface IUserNotificationService
{
    Task<UserNotification?> GetAsync(
        Expression<Func<UserNotification, bool>> predicate,
        Func<IQueryable<UserNotification>, IIncludableQueryable<UserNotification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserNotification>?> GetListAsync(
        Expression<Func<UserNotification, bool>>? predicate = null,
        Func<IQueryable<UserNotification>, IOrderedQueryable<UserNotification>>? orderBy = null,
        Func<IQueryable<UserNotification>, IIncludableQueryable<UserNotification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserNotification> AddAsync(UserNotification userNotification);
    Task<UserNotification> UpdateAsync(UserNotification userNotification);
    Task<UserNotification> DeleteAsync(UserNotification userNotification, bool permanent = false);
}
