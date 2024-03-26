using Application.Features.UserActivities.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserActivities;

public class UserActivityManager : IUserActivityService
{
    private readonly IUserActivityRepository _userActivityRepository;
    private readonly UserActivityBusinessRules _userActivityBusinessRules;

    public UserActivityManager(IUserActivityRepository userActivityRepository, UserActivityBusinessRules userActivityBusinessRules)
    {
        _userActivityRepository = userActivityRepository;
        _userActivityBusinessRules = userActivityBusinessRules;
    }

    public async Task<UserActivity?> GetAsync(
        Expression<Func<UserActivity, bool>> predicate,
        Func<IQueryable<UserActivity>, IIncludableQueryable<UserActivity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserActivity? userActivity = await _userActivityRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userActivity;
    }

    public async Task<IPaginate<UserActivity>?> GetListAsync(
        Expression<Func<UserActivity, bool>>? predicate = null,
        Func<IQueryable<UserActivity>, IOrderedQueryable<UserActivity>>? orderBy = null,
        Func<IQueryable<UserActivity>, IIncludableQueryable<UserActivity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserActivity> userActivityList = await _userActivityRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userActivityList;
    }

    public async Task<UserActivity> AddAsync(UserActivity userActivity)
    {
        UserActivity addedUserActivity = await _userActivityRepository.AddAsync(userActivity);

        return addedUserActivity;
    }

    public async Task<UserActivity> UpdateAsync(UserActivity userActivity)
    {
        UserActivity updatedUserActivity = await _userActivityRepository.UpdateAsync(userActivity);

        return updatedUserActivity;
    }

    public async Task<UserActivity> DeleteAsync(UserActivity userActivity, bool permanent = false)
    {
        UserActivity deletedUserActivity = await _userActivityRepository.DeleteAsync(userActivity);

        return deletedUserActivity;
    }
}
