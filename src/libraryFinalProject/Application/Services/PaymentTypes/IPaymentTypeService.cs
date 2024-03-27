using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PaymentTypes;

public interface IPaymentTypeService
{
    Task<PaymentType?> GetAsync(
        Expression<Func<PaymentType, bool>> predicate,
        Func<IQueryable<PaymentType>, IIncludableQueryable<PaymentType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PaymentType>?> GetListAsync(
        Expression<Func<PaymentType, bool>>? predicate = null,
        Func<IQueryable<PaymentType>, IOrderedQueryable<PaymentType>>? orderBy = null,
        Func<IQueryable<PaymentType>, IIncludableQueryable<PaymentType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PaymentType> AddAsync(PaymentType paymentType);
    Task<PaymentType> UpdateAsync(PaymentType paymentType);
    Task<PaymentType> DeleteAsync(PaymentType paymentType, bool permanent = false);
}
