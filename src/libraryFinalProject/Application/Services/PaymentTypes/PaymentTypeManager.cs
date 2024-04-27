using Application.Features.PaymentTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PaymentTypes;

public class PaymentTypeManager : IPaymentTypeService
{
    private readonly IPaymentTypeRepository _paymentTypeRepository;
    private readonly PaymentTypeBusinessRules _paymentTypeBusinessRules;

    public PaymentTypeManager(IPaymentTypeRepository paymentTypeRepository, PaymentTypeBusinessRules paymentTypeBusinessRules)
    {
        _paymentTypeRepository = paymentTypeRepository;
        _paymentTypeBusinessRules = paymentTypeBusinessRules;
    }

    public async Task<PaymentType?> GetAsync(
        Expression<Func<PaymentType, bool>> predicate,
        Func<IQueryable<PaymentType>, IIncludableQueryable<PaymentType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PaymentType? paymentType = await _paymentTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return paymentType;
    }

    public async Task<IPaginate<PaymentType>?> GetListAsync(
        Expression<Func<PaymentType, bool>>? predicate = null,
        Func<IQueryable<PaymentType>, IOrderedQueryable<PaymentType>>? orderBy = null,
        Func<IQueryable<PaymentType>, IIncludableQueryable<PaymentType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PaymentType> paymentTypeList = await _paymentTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return paymentTypeList;
    }

    public async Task<PaymentType> AddAsync(PaymentType paymentType)
    {
        PaymentType addedPaymentType = await _paymentTypeRepository.AddAsync(paymentType);

        return addedPaymentType;
    }

    public async Task<PaymentType> UpdateAsync(PaymentType paymentType)
    {
        PaymentType updatedPaymentType = await _paymentTypeRepository.UpdateAsync(paymentType);

        return updatedPaymentType;
    }

    public async Task<PaymentType> DeleteAsync(PaymentType paymentType, bool permanent = false)
    {
        PaymentType deletedPaymentType = await _paymentTypeRepository.DeleteAsync(paymentType);

        return deletedPaymentType;
    }
}
