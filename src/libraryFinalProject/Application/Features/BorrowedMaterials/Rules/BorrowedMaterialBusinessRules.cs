using Application.Features.BorrowedMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Baskets.Constants;
using Application.Features.Materials.Constants;

namespace Application.Features.BorrowedMaterials.Rules;

public class BorrowedMaterialBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;//
    private readonly IMaterialRepository _materialRepository;//
    private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IReservationRepository _reservationRepository;

    public BorrowedMaterialBusinessRules(IBorrowedMaterialRepository borrowedMaterialRepository, ILocalizationService localizationService, IUserRepository userRepository, IMaterialRepository materialRepository, IReservationRepository reservationRepository)
    {
        _borrowedMaterialRepository = borrowedMaterialRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;//ctora userrepo eklendi
        _materialRepository = materialRepository;//ctoramaterialrepo eklendi
        _reservationRepository = reservationRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BorrowedMaterialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BorrowedMaterialShouldExistWhenSelected(BorrowedMaterial? borrowedMaterial)
    {
        if (borrowedMaterial == null)
            await throwBusinessException(BorrowedMaterialsBusinessMessages.BorrowedMaterialNotExists);
    }

    public async Task BorrowedMaterialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BorrowedMaterial? borrowedMaterial = await _borrowedMaterialRepository.GetAsync(
            predicate: bm => bm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BorrowedMaterialShouldExistWhenSelected(borrowedMaterial);
    }
    ///
    //Girilen Userid de�eri mevcut de�ilse hata kodu f�rlat
    public async Task UserShouldExist(Guid userId)
    {
        // Veritaban�nda belirtilen User ID de�erine sahip user var m� kontrol et
        var user = await _userRepository.GetAsync(
            predicate: c => c.Id == userId,
            enableTracking: false
        );

        // E�er user bulunamazsa, uygun hata mesaj�n� olu�tur ve bir istisna f�rlat
        if (user == null)
        {
            await throwBusinessException(BorrowedMaterialsBusinessMessages.UserNotExists);//hata mesaj� tan�m�
        }
    }

    public async Task<Material> MaterialCheck(Guid id)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false
        );
        return material;
    }

    //Girilen Materyalid de�eri mevcut de�ilse hata kodu f�rlat
    public async Task MaterialShouldExist(Guid materialId)
    {
        // Veritaban�nda belirtilen Material ID de�erine sahip materyal var m� kontrol et
        var material = await MaterialCheck(materialId);

        // E�er materialr bulunamazsa, uygun hata mesaj�n� olu�tur ve bir istisna f�rlat
        if (material.Id == null)
            await throwBusinessException(BorrowedMaterialsBusinessMessages.MaterialNotExists);//hata mesaj� tan�m�
        else if (material.Quantity == 0)
            await throwBusinessException(MaterialsBusinessMessages.QuanityIsZero);
        else
        {
            material.Quantity -= 1;
            await _materialRepository.UpdateAsync(material);
        }
        
    }
    public async Task<Material> MaterialCheck(Guid id)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false
        );
        return material;
    }
    public async Task<bool> MaterialQuantityShouldGreaterThenZero(Guid materialId, Guid userId)
    {
        bool isZero = true;
        Reservation? reservation = await _reservationRepository.GetAsync(
            predicate: r => r.Status == true
            );
        var material = await MaterialCheck(materialId);
        if (material.Quantity == 0)
        {
            var reservationCreate = new Reservation();
            reservationCreate.MaterialId = materialId;
            reservationCreate.UserId = userId;
            await _reservationRepository.AddAsync(reservationCreate);
        }
        else
        {
            isZero = false;
        }
        return isZero;
    }


    public async Task MaterialQuantityShouldGreaterThenZero(Guid materialId, Guid userId)
    {
        Reservation? reservation = await _reservationRepository.GetAsync(
            predicate: r => r.Status == true
            );
        var material = await MaterialCheck(materialId);
        if (material.Quantity == 0)
        {
            var reservationCreate = new Reservation();
            reservationCreate.MaterialId = materialId;
            reservationCreate.UserId = userId;
            await _reservationRepository.AddAsync(reservationCreate);
            await throwBusinessException(MaterialsBusinessMessages.QuanityIsZero);
        }
    }

}