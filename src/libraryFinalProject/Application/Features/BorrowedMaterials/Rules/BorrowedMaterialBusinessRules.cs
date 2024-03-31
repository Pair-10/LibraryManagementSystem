using Application.Features.BorrowedMaterials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Baskets.Constants;

namespace Application.Features.BorrowedMaterials.Rules;

public class BorrowedMaterialBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;//
    private readonly IMaterialRepository _materialRepository;//
    private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
    private readonly ILocalizationService _localizationService;

    public BorrowedMaterialBusinessRules(IBorrowedMaterialRepository borrowedMaterialRepository, ILocalizationService localizationService, IUserRepository userRepository, IMaterialRepository materialRepository)
    {
        _borrowedMaterialRepository = borrowedMaterialRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;//ctora userrepo eklendi
        _materialRepository = materialRepository;//ctoramaterialrepo eklendi
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
    //Girilen Materyalid de�eri mevcut de�ilse hata kodu f�rlat
    public async Task MaterialShouldExist(Guid materialId)
    {
        // Veritaban�nda belirtilen Material ID de�erine sahip materyal var m� kontrol et
        var material = await _materialRepository.GetAsync(
            predicate: c => c.Id == materialId,
            enableTracking: false
        );

        // E�er materialr bulunamazsa, uygun hata mesaj�n� olu�tur ve bir istisna f�rlat
        if (material == null)
        {
            await throwBusinessException(BorrowedMaterialsBusinessMessages.MaterialNotExists);//hata mesaj� tan�m�
        }
    }

}