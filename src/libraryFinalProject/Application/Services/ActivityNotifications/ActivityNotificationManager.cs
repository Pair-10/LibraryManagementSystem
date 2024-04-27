using Application.Features.ActivityNotifications.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ActivityNotifications;

public class ActivityNotificationManager : IActivityNotificationService
{
    private readonly IActivityNotificationRepository _activityNotificationRepository;
    private readonly ActivityNotificationBusinessRules _activityNotificationBusinessRules;

    public ActivityNotificationManager(IActivityNotificationRepository activityNotificationRepository, ActivityNotificationBusinessRules activityNotificationBusinessRules)
    {
        _activityNotificationRepository = activityNotificationRepository;
        _activityNotificationBusinessRules = activityNotificationBusinessRules;
    }

    public async Task<ActivityNotification?> GetAsync(
        Expression<Func<ActivityNotification, bool>> predicate,
        Func<IQueryable<ActivityNotification>, IIncludableQueryable<ActivityNotification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ActivityNotification? activityNotification = await _activityNotificationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return activityNotification;
    }

    public async Task<IPaginate<ActivityNotification>?> GetListAsync(
        Expression<Func<ActivityNotification, bool>>? predicate = null,
        Func<IQueryable<ActivityNotification>, IOrderedQueryable<ActivityNotification>>? orderBy = null,
        Func<IQueryable<ActivityNotification>, IIncludableQueryable<ActivityNotification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ActivityNotification> activityNotificationList = await _activityNotificationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return activityNotificationList;
    }

    public async Task<ActivityNotification> AddAsync(ActivityNotification activityNotification)
    {
        ActivityNotification addedActivityNotification = await _activityNotificationRepository.AddAsync(activityNotification);

        return addedActivityNotification;
    }

    public async Task<ActivityNotification> UpdateAsync(ActivityNotification activityNotification)
    {
        ActivityNotification updatedActivityNotification = await _activityNotificationRepository.UpdateAsync(activityNotification);

        return updatedActivityNotification;
    }

    public async Task<ActivityNotification> DeleteAsync(ActivityNotification activityNotification, bool permanent = false)
    {
        ActivityNotification deletedActivityNotification = await _activityNotificationRepository.DeleteAsync(activityNotification);

        return deletedActivityNotification;
    }
}
