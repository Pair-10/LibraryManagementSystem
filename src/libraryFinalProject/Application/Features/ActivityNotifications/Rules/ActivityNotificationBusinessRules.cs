using Application.Features.ActivityNotifications.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ActivityNotifications.Rules;

public class ActivityNotificationBusinessRules : BaseBusinessRules
{
    private readonly IActivityNotificationRepository _activityNotificationRepository;
    private readonly ILocalizationService _localizationService;

    public ActivityNotificationBusinessRules(IActivityNotificationRepository activityNotificationRepository, ILocalizationService localizationService)
    {
        _activityNotificationRepository = activityNotificationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ActivityNotificationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ActivityNotificationShouldExistWhenSelected(ActivityNotification? activityNotification)
    {
        if (activityNotification == null)
            await throwBusinessException(ActivityNotificationsBusinessMessages.ActivityNotificationNotExists);
    }

    public async Task ActivityNotificationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ActivityNotification? activityNotification = await _activityNotificationRepository.GetAsync(
            predicate: an => an.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ActivityNotificationShouldExistWhenSelected(activityNotification);
    }
}