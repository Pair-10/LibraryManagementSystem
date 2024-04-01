using Application.Features.ActivityNotifications.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.BasketEmaterials.Constants;
using System.Diagnostics;
using MediatR;

namespace Application.Features.ActivityNotifications.Rules;

public class ActivityNotificationBusinessRules : BaseBusinessRules
{
    private readonly IActivityRepository _activityRepository;//
    private readonly INotificationRepository _notificationRepository;//
    private readonly IActivityNotificationRepository _activityNotificationRepository;
    private readonly ILocalizationService _localizationService;

    public ActivityNotificationBusinessRules(IActivityNotificationRepository activityNotificationRepository, ILocalizationService localizationService, IActivityRepository activityRepository, INotificationRepository notificationRepository)
    {
        _activityNotificationRepository = activityNotificationRepository;
        _localizationService = localizationService;
        _activityRepository = activityRepository;//ctor activityrepo eklendi   
        _notificationRepository = notificationRepository;//ctor notificationrepo eklendi   
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
    ///
    //Girilen  Activityid deðeri mevcut deðilse hata kodu fýrlat
    public async Task ActivityIdShouldExist(Guid activityId)//
    {
        // Veritabanýnda belirtilen Activity ID deðerine sahip aktivite var mý kontrol et
        var activity = await _activityRepository.GetAsync(
            predicate: c => c.Id == activityId,
            enableTracking: false//
        );

        // Eðer activity bulunamazsa, uygun hata mesajýný oluþtur ve bir istisna fýrlat
        if (activity == null)
        {
            await throwBusinessException(ActivityNotificationsBusinessMessages.ActivityNotExists);//hata mesajý tanýmý
        }
    }
    //Girilen Notificationid deðeri mevcut deðilse hata kodu fýrlat
    public async Task NotificationIdShouldExist(Guid notificationId)
    {
        // Veritabanýnda belirtilen Notification ID deðerine sahip bildirim var mý kontrol et
        var notification = await _notificationRepository.GetAsync(
            predicate: c => c.Id == notificationId,
            enableTracking: false
        );

        // Eðer Notification bulunamazsa, uygun hata mesajýný oluþtur ve bir istisna fýrlat
        if (notification == null)
        {
            await throwBusinessException(ActivityNotificationsBusinessMessages.NotificationNotExists);//hata mesajý tanýmý
        }
    }
}