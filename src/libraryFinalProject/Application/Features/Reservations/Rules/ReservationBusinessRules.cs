using Application.Features.Reservations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Users.Constants;
using Nest;
using Application.Features.Materials.Constants;

namespace Application.Features.Reservations.Rules;

public class ReservationBusinessRules : BaseBusinessRules
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IUserRepository _userRepository;
    private readonly IMaterialRepository _materialRepository;

    public ReservationBusinessRules(IReservationRepository reservationRepository, ILocalizationService localizationService, IUserRepository _userRepository, IMaterialRepository _materialRepository)
    {
        _reservationRepository = reservationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ReservationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ReservationShouldExistWhenSelected(Reservation? reservation)
    {
        if (reservation == null)
            await throwBusinessException(ReservationsBusinessMessages.ReservationNotExists);
    }

    public async Task ReservationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Reservation? reservation = await _reservationRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ReservationShouldExistWhenSelected(reservation);
    }
    public async Task UserIdShouldBeExistsWhen(Guid id)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Id == id);
        if (doesExist)
            await throwBusinessException(UsersMessages.UserDontExists);
    }
    public async Task MaterialIdShouldExistWhen(Guid id)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false
        );
        if(material == null)
            await throwBusinessException(MaterialsBusinessMessages.MaterialNotExists);
    }

}