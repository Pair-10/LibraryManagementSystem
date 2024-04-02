using Application.Features.UserNotifications.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserNotifications;

public class UserNotificationManager : IUserNotificationService
{
    private readonly IUserNotificationRepository _userNotificationRepository;
    private readonly UserNotificationBusinessRules _userNotificationBusinessRules;

    public UserNotificationManager(IUserNotificationRepository userNotificationRepository, UserNotificationBusinessRules userNotificationBusinessRules)
    {
        _userNotificationRepository = userNotificationRepository;
        _userNotificationBusinessRules = userNotificationBusinessRules;
    }

    public async Task<UserNotification?> GetAsync(
        Expression<Func<UserNotification, bool>> predicate,
        Func<IQueryable<UserNotification>, IIncludableQueryable<UserNotification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserNotification? userNotification = await _userNotificationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userNotification;
    }

    public async Task<IPaginate<UserNotification>?> GetListAsync(
        Expression<Func<UserNotification, bool>>? predicate = null,
        Func<IQueryable<UserNotification>, IOrderedQueryable<UserNotification>>? orderBy = null,
        Func<IQueryable<UserNotification>, IIncludableQueryable<UserNotification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserNotification> userNotificationList = await _userNotificationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userNotificationList;
    }

    public async Task<UserNotification> AddAsync(UserNotification userNotification)
    {
        UserNotification addedUserNotification = await _userNotificationRepository.AddAsync(userNotification);

        return addedUserNotification;
    }

    public async Task<UserNotification> UpdateAsync(UserNotification userNotification)
    {
        UserNotification updatedUserNotification = await _userNotificationRepository.UpdateAsync(userNotification);

        return updatedUserNotification;
    }

    public async Task<UserNotification> DeleteAsync(UserNotification userNotification, bool permanent = false)
    {
        UserNotification deletedUserNotification = await _userNotificationRepository.DeleteAsync(userNotification);

        return deletedUserNotification;
    }
}
