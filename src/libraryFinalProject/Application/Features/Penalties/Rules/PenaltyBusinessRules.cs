using Application.Features.Penalties.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using System.Threading;
using Application.Features.Returneds.Constants;
using Application.Features.Payments.Constants;

namespace Application.Features.Penalties.Rules;

public class PenaltyBusinessRules : BaseBusinessRules
{
    private readonly IPenaltyRepository _penaltyRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IReturnedRepository _returnedRepository;
    private readonly IPaymentRepository _paymentRepository;

    public PenaltyBusinessRules(IPenaltyRepository penaltyRepository, ILocalizationService localizationService, IReturnedRepository returnedRepository, IPaymentRepository paymentRepository)
    {
        _penaltyRepository = penaltyRepository;
        _localizationService = localizationService;
        _returnedRepository = returnedRepository;
        _paymentRepository = paymentRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PenaltiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PenaltyShouldExistWhenSelected(Penalty? penalty)
    {
        if (penalty == null)
            await throwBusinessException(PenaltiesBusinessMessages.PenaltyNotExists);
    }

    public async Task PenaltyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Penalty? penalty = await _penaltyRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PenaltyShouldExistWhenSelected(penalty);
    }
    public async Task ReturnedIdShouldExist(Guid id)
    {
        Returned? returned = await _returnedRepository.GetAsync(
              predicate: r => r.Id == id,
        enableTracking: false
        );
        if (returned == null)
            await throwBusinessException(ReturnedsBusinessMessages.ReturnedNotExists);
            
    }

    public async Task PaymentIdShouldExist(Guid paymentId)
    {

        var payment = await _paymentRepository.GetAsync(
            predicate: p => p.Id == paymentId,
            enableTracking: false
        );


        if (payment == null)
        {
            await throwBusinessException(PaymentsBusinessMessages.PaymentNotExists);//hata mesajý tanýmý
        }
    }
}