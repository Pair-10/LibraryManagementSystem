using Application.Features.UserActivities.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserActivities.Rules;

public class UserActivityBusinessRules : BaseBusinessRules
{
    private readonly IUserActivityRepository _userActivityRepository;
    private readonly ILocalizationService _localizationService;

    public UserActivityBusinessRules(IUserActivityRepository userActivityRepository, ILocalizationService localizationService)
    {
        _userActivityRepository = userActivityRepository;
        _localizationService = localizationService;
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
}