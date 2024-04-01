using Application.Features.Activities.Constants;
using Application.Features.UserActivities.Constants;
using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.UserActivities.Rules;

public class UserActivityBusinessRules : BaseBusinessRules
{
    private readonly IUserActivityRepository _userActivityRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IUserRepository _userRepository;
    private readonly IActivityRepository _activityRepository;

    public UserActivityBusinessRules(IUserActivityRepository userActivityRepository, ILocalizationService localizationService, IUserRepository userRepository, IActivityRepository activityRepository)
    {
        _userActivityRepository = userActivityRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
        _activityRepository = activityRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserActivitiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserActivityShouldExistWhenSelected(UserActivity? userActivity)
    {
        if (userActivity == null)
            await throwBusinessException(UserActivitiesBusinessMessages.UserActivityNotExists);
    }

    public async Task UserActivityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserActivity? userActivity = await _userActivityRepository.GetAsync(
            predicate: ua => ua.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserActivityShouldExistWhenSelected(userActivity);
    }
    public async Task UserShouldExistWhenSelected(User? user)
    {
        if (user == null)
            await throwBusinessException(UsersMessages.UserDontExists);
    }

    public async Task UserIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserShouldExistWhenSelected(user);
    }

    public async Task ActivityShouldExistWhenSelected(Activity? activity)
    {
        if (activity == null)
            await throwBusinessException(ActivitiesBusinessMessages.ActivityNotExists);
    }

    public async Task ActivityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Activity? activity = await _activityRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ActivityShouldExistWhenSelected(activity);
    }
}