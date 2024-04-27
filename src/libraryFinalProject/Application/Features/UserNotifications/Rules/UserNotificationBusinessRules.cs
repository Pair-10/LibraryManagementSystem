using Application.Features.UserNotifications.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Users.Constants;
using Application.Features.Notifications.Constants;

namespace Application.Features.UserNotifications.Rules;

public class UserNotificationBusinessRules : BaseBusinessRules
{
    private readonly IUserNotificationRepository _userNotificationRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IUserRepository _userRepository;
    private readonly INotificationRepository _notificationRepository;

    public UserNotificationBusinessRules(IUserNotificationRepository userNotificationRepository, ILocalizationService localizationService, IUserRepository userRepository, INotificationRepository notificationRepository)
    {
        _userNotificationRepository = userNotificationRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
        _notificationRepository = notificationRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserNotificationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserNotificationShouldExistWhenSelected(UserNotification? userNotification)
    {
        if (userNotification == null)
            await throwBusinessException(UserNotificationsBusinessMessages.UserNotificationNotExists);
    }

    public async Task UserNotificationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserNotification? userNotification = await _userNotificationRepository.GetAsync(
            predicate: un => un.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserNotificationShouldExistWhenSelected(userNotification);
    }
    public async Task UserShouldExist(Guid id)
    {
        User? user = await _userRepository.GetAsync(
            predicate: u => u.Id == id,
            enableTracking: false
            );
        if (user == null)
            await throwBusinessException(UsersMessages.UserDontExists);
    }
    public async Task NotificationShouldExist(Guid id)
    {
        Notification? notification = await _notificationRepository.GetAsync(
            predicate: n => n.Id == id,
            enableTracking: false
            );
        if (notification == null)
            await throwBusinessException(NotificationsBusinessMessages.NotificationNotExists);
    }
}