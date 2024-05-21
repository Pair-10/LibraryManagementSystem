using Application.Features.BorrowedMaterials.Constants;
using Application.Features.Materials.Constants;
using Application.Features.Returneds.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using MimeKit;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Returneds.Rules;

public class ReturnedBusinessRules : BaseBusinessRules
{
    private readonly IReturnedRepository _returnedRepository;
    private readonly IUserNotificationRepository _userNotificationRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
    private readonly IPenaltyRepository _penaltyRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly INotificationRepository _notificationRepository;
    private readonly IMailService _mailService;
    private readonly IUserRepository _userRepository;

    public ReturnedBusinessRules(IReturnedRepository returnedRepository, ILocalizationService localizationService, IBorrowedMaterialRepository borrowedMaterialRepository, IPenaltyRepository penaltyRepository, IMaterialRepository materialRepository, IMailService mailService, IUserRepository userRepository, IReservationRepository reservationRepository = null, INotificationRepository notificationRepository = null)
    {
        _returnedRepository = returnedRepository;
        _localizationService = localizationService;
        _borrowedMaterialRepository = borrowedMaterialRepository;
        _penaltyRepository = penaltyRepository;
        _materialRepository = materialRepository;
        _reservationRepository = reservationRepository;
        _notificationRepository = notificationRepository;
        _mailService = mailService;
        _userRepository = userRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ReturnedsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ReturnedShouldExistWhenSelected(Returned? returned)
    {
        if (returned == null)
            await throwBusinessException(ReturnedsBusinessMessages.ReturnedNotExists);
    }

    public async Task ReturnedIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Returned? returned = await _returnedRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ReturnedShouldExistWhenSelected(returned);
    }
    public async Task BorrowedMaterialShouldExistWhenSelected(BorrowedMaterial? borrowedMaterial)
    {
        if (borrowedMaterial == null)
            await throwBusinessException(BorrowedMaterialsBusinessMessages.BorrowedMaterialNotExists);
    }

    public async Task BorrowedMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BorrowedMaterial? borrowedMaterial = await _borrowedMaterialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BorrowedMaterialShouldExistWhenSelected(borrowedMaterial);
    }
    public async Task CheckingTheDeliveryTime(Guid id, Guid borrowedMaterialId, CancellationToken cancellationToken)
    {
        BorrowedMaterial? deadlineControl =
             await _borrowedMaterialRepository.GetAsync(
             predicate: m => m.UserId == id && m.Id == borrowedMaterialId,
         enableTracking: false,
             cancellationToken: cancellationToken

         );
        Returned? returnControl =
            await _returnedRepository.GetAsync(
            predicate: m => m.BorrowedMaterialId == deadlineControl.Id,
        enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (deadlineControl.Deadline < returnControl.CreatedDate)
        {
            returnControl.IsPenalised = true;
            await CalculateThePenaltyAmount(deadlineControl, returnControl, returnControl.IsPenalised, deadlineControl.Deadline, returnControl.CreatedDate, cancellationToken);
        }
        await IncreaseMaterialQuantity(deadlineControl.MaterialId);

    }
    public async Task CalculateThePenaltyAmount(BorrowedMaterial borrowedMaterial, Returned returnControl, bool isPenalised, DateTime deadline, DateTime returnDate, CancellationToken cancellationToken)
    {
        TimeSpan difference = deadline - returnDate;
        int dayDifference = Math.Abs(difference.Days);

        Console.WriteLine("Total days brought late : " + dayDifference);
        decimal TotalPunishment = dayDifference * 10;
        await Console.Out.WriteLineAsync("The amount of the penalty : " + TotalPunishment);
        if (isPenalised)
        {
            var penalty = new Penalty(returnControl.Id, TotalPunishment, dayDifference, isPenalised, borrowedMaterial.UserId);
            penalty.PenaltyPrice = TotalPunishment;
            penalty.TotalPenaltyDays = dayDifference;
            penalty.PenaltyStatus = isPenalised;
            penalty.ReturnedId = returnControl.Id;
            penalty.UserId = borrowedMaterial.UserId;
            penalty.MaterialId = borrowedMaterial.MaterialId;
            await _penaltyRepository.AddAsync(penalty);
        }
    }

    public async Task IncreaseMaterialQuantity(Guid materialId)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == materialId,
            enableTracking: false
        );
        if (material != null)
        {
            material.Quantity += 1;
            await _materialRepository.UpdateAsync(material);
            await GetReservation(material.Id);
        }
        else
            await throwBusinessException(MaterialsBusinessMessages.MaterialNotExists);


    }

    public async Task GetReservation(Guid materialId)
    {
        IPaginate<Reservation> reservation = await _reservationRepository.GetListAsync(
         predicate: r => r.Status == true && r.MaterialId == materialId
         );
        Notification? notification = await _notificationRepository.GetAsync(
            predicate: n => n.NotificationType == "Rezervasyon Hatýrlatma",
             enableTracking: false
            );

        IEnumerable<Reservation> reservations = reservation.Items;
        if (reservation != null && notification != null)
        {
            foreach (var rs in reservations)
            {
                UserNotification userNotification = new UserNotification();
                userNotification.UserId = rs.UserId;
                userNotification.NotificationId = notification.Id;
                await _userNotificationRepository.AddAsync(userNotification);

                Material? materials = await _materialRepository.GetAsync(
                     predicate: m => m.Id == rs.MaterialId
                 );
                User? user = await _userRepository.GetAsync(
                    predicate: u => u.Id == rs.UserId
                    );
                Mail mail = new Mail(
                    subject: "Rezervasyon Hatýrlatma",
                    textBody: $"{materials.MaterialName} isimli rezarvasyon ettiðiniz materyalin stoðu bulunmaktadýr.",
                    htmlBody: $"<p>{materials.MaterialName} isimli rezarvasyon ettiðiniz materyalin stoðu bulunmaktadýr..</p>",
                    new List<MailboxAddress>() {
                        new($"Kullanici","kullanici@deneme.com")
                    });
                await _mailService.SendEmailAsync(mail);
            }
        }

    }


}

