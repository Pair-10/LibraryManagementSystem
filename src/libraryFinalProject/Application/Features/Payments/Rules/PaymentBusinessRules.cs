using Application.Features.Payments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Users.Constants;

namespace Application.Features.Payments.Rules;

public class PaymentBusinessRules : BaseBusinessRules
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IOrderRepository _orderRepository; 
    private readonly IUserRepository _userRepository;
    public PaymentBusinessRules(IPaymentRepository paymentRepository, IOrderRepository orderRepository, ILocalizationService localizationService, IUserRepository userRepository)
    {
        _paymentRepository = paymentRepository;
        _localizationService = localizationService;
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PaymentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PaymentShouldExistWhenSelected(Payment? payment)
    {
        if (payment == null)
            await throwBusinessException(PaymentsBusinessMessages.PaymentNotExists);
    }

    public async Task PaymentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Payment? payment = await _paymentRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PaymentShouldExistWhenSelected(payment);
    }
    // iþ kuralý
    // sipariþ var mý yok mu bunu kontrol ediyor
    public async Task PaymentOrderRelationshipShouldBeValid(Guid orderId)
    {
     
        Order? order = await _orderRepository.GetAsync(
            predicate: o => o.Id == orderId,
            enableTracking: false
        );

        if (order == null)
        {
            await throwBusinessException(PaymentsBusinessMessages.InvalidOrder);
        }
    }
    public async Task UserIdShouldBeExists(Guid id)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Id == id);
        if (doesExist)
            await throwBusinessException(UsersMessages.UserDontExists);
    }
}
