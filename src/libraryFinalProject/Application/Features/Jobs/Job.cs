namespace Application.Features.Jobs;
using Application.Services.Repositories;
using Domain.Entities;
using MimeKit;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Persistence.Paging;

public class Job
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
    private readonly IUserNotificationRepository _userNotificationRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly IMailService _mailService;
    private readonly IUserRepository _userRepository;

    public Job(INotificationRepository notificationRepository, IBorrowedMaterialRepository borrowedMaterialRepository, IUserNotificationRepository userNotificationRepository, IMaterialRepository materialRepository, IMailService mailService, IUserRepository userRepository)
    {
        _notificationRepository = notificationRepository;
        _borrowedMaterialRepository = borrowedMaterialRepository;
        _userNotificationRepository = userNotificationRepository;
        _materialRepository = materialRepository;
        _mailService = mailService;
        _userRepository = userRepository;
    }

    public async Task ControlTheReturnDate()
    {
        IPaginate<BorrowedMaterial> borrowedMaterial = await _borrowedMaterialRepository.GetListAsync(
            predicate: b => b.Deadline != DateTime.Now,
            index: 0,
            size: 100
            );

        Notification? notification = await _notificationRepository.GetAsync(
            predicate: n => n.NotificationType == "IadeHatirlatma"
            );
        UserNotification? userNotification = await _userNotificationRepository.GetAsync(
            predicate: un => un.Id != null
            );

        IEnumerable<BorrowedMaterial> borrowedMaterials = borrowedMaterial.Items;
        foreach (var material in borrowedMaterials)
        {
            if (DateTime.Now.Day == material.Deadline.AddDays(-1).Day && notification != null)
            {
                Material? materials = await _materialRepository.GetAsync(
                predicate: m => m.Id == material.MaterialId
            );
                User? user = await _userRepository.GetAsync(
                    predicate: u => u.Id == material.UserId
                    );
                Mail mail = new Mail(
                    subject: "Iade Hatirlatma",
                    textBody: $"{materials.MaterialName} isimli aldiginiz materyalin iade tarihine 1 gun kalmistir.",
                    htmlBody: $"<p>{materials.MaterialName} isimli aldiginiz materyalin iade tarihine 1 gun kalmistir.</p>",
                    new List<MailboxAddress>() {
                        new($"Kullanici","kullanici@deneme.com")
                    });
                await _mailService.SendEmailAsync(mail);
                var createUserNotification = new UserNotification();
                createUserNotification.UserId = material.UserId;
                createUserNotification.NotificationId = notification.Id;
                await _userNotificationRepository.AddAsync(createUserNotification);
            }
        }


    }
}
