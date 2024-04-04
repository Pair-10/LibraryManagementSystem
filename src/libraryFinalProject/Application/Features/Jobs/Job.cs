namespace Application.Features.Jobs;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

public class Job
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
    private readonly IUserNotificationRepository _userNotificationRepository;

    public  Job(INotificationRepository notificationRepository, IBorrowedMaterialRepository borrowedMaterialRepository, IUserNotificationRepository userNotificationRepository )
    {
        _notificationRepository = notificationRepository;
        _borrowedMaterialRepository = borrowedMaterialRepository;
        _userNotificationRepository = userNotificationRepository;
    }

    public async Task Control()
    {
        IPaginate<BorrowedMaterial> borrowedMaterial = await _borrowedMaterialRepository.GetListAsync(
            predicate: b => b.Deadline != DateTime.Now
            );
        Notification? notification = await _notificationRepository.GetAsync(
            predicate: n => n.NotificationType == "IadeHatirlatma"
            );
        UserNotification? userNotification = await _userNotificationRepository.GetAsync(
            predicate: un => un.Id != null
            );
        IEnumerable<BorrowedMaterial> borrowedMaterials = borrowedMaterial.Items;
        foreach( var material in borrowedMaterials ) {
            if( DateTime.Now.Day == material.Deadline.AddDays(-1).Day && notification != null)
            {
                var createUserNotification = new UserNotification();
                createUserNotification.UserId = material.UserId;
                createUserNotification.NotificationId = notification.Id;
                await _userNotificationRepository.AddAsync(createUserNotification);
            }
        }


    }
}
