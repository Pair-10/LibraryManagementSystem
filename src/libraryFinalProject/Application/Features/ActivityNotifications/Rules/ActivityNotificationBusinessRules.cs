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
    //Girilen  Activityid de�eri mevcut de�ilse hata kodu f�rlat
    public async Task ActivityIdShouldExist(Guid activityId)//
    {
        // Veritaban�nda belirtilen Activity ID de�erine sahip aktivite var m� kontrol et
        var activity = await _activityRepository.GetAsync(
            predicate: c => c.Id == activityId,
            enableTracking: false//
        );

        // E�er activity bulunamazsa, uygun hata mesaj�n� olu�tur ve bir istisna f�rlat
        if (activity == null)
        {
            await throwBusinessException(ActivityNotificationsBusinessMessages.ActivityNotExists);//hata mesaj� tan�m�
        }
    }
    //Girilen Notificationid de�eri mevcut de�ilse hata kodu f�rlat
    public async Task NotificationIdShouldExist(Guid notificationId)
    {
        // Veritaban�nda belirtilen Notification ID de�erine sahip bildirim var m� kontrol et
        var notification = await _notificationRepository.GetAsync(
            predicate: c => c.Id == notificationId,
            enableTracking: false
        );

        // E�er Notification bulunamazsa, uygun hata mesaj�n� olu�tur ve bir istisna f�rlat
        if (notification == null)
        {
            await throwBusinessException(ActivityNotificationsBusinessMessages.NotificationNotExists);//hata mesaj� tan�m�
        }
    }
}