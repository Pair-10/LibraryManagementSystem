using Application.Features.BorrowedMaterials.Constants;
using Application.Features.Returneds.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Returneds.Rules;

public class ReturnedBusinessRules : BaseBusinessRules
{
    private readonly IReturnedRepository _returnedRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;

    public ReturnedBusinessRules(IReturnedRepository returnedRepository, ILocalizationService localizationService, IBorrowedMaterialRepository borrowedMaterialRepository)
    {
        _returnedRepository = returnedRepository;
        _localizationService = localizationService;
        _borrowedMaterialRepository = borrowedMaterialRepository;
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
    public async Task CheckingTheDeliveryTime(Guid id, CancellationToken cancellationToken)
    {
        BorrowedMaterial? deadlineControl =
             await _borrowedMaterialRepository.GetAsync(
             predicate: m => m.UserId == id,
         enableTracking: false,
             cancellationToken: cancellationToken

         );
        Returned? returnControl =
            await _returnedRepository.GetAsync(
            predicate: m => m.BorrowedMaterialId == deadlineControl.Id,
        enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (deadlineControl.Deadline > returnControl.CreatedDate)
        {
            returnControl.IsPenalised = true;
            await CalculateThePenaltyAmount(deadlineControl.Deadline, returnControl.CreatedDate, cancellationToken);
        }


    }
    public async Task CalculateThePenaltyAmount(DateTime deadline, DateTime returnDate, CancellationToken cancellationToken)
    {
        /*BorrowedMaterial? deadlineControl = await _borrowedMaterialRepository.GetAsync(
            predicate: m => m.Deadline == deadline,
        enableTracking: false,
            cancellationToken: cancellationToken
        );
        Returned? returnControl = await _returnedRepository.GetAsync(
            predicate: m => m.CreatedDate == returnDate,
        enableTracking: false,
            cancellationToken: cancellationToken
        ); */
        TimeSpan difference = deadline - returnDate;
        int dayDifference = difference.Days;

        Console.WriteLine("Geç kalýnan gün adeti : " + dayDifference);
        int TotalPunishment = dayDifference * 10;
        await Console.Out.WriteLineAsync("Ceza tutarý : " + TotalPunishment);
    }
}