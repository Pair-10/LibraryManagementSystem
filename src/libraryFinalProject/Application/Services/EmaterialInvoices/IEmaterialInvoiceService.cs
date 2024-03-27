using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EmaterialInvoices;

public interface IEmaterialInvoiceService
{
    Task<EmaterialInvoice?> GetAsync(
        Expression<Func<EmaterialInvoice, bool>> predicate,
        Func<IQueryable<EmaterialInvoice>, IIncludableQueryable<EmaterialInvoice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EmaterialInvoice>?> GetListAsync(
        Expression<Func<EmaterialInvoice, bool>>? predicate = null,
        Func<IQueryable<EmaterialInvoice>, IOrderedQueryable<EmaterialInvoice>>? orderBy = null,
        Func<IQueryable<EmaterialInvoice>, IIncludableQueryable<EmaterialInvoice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EmaterialInvoice> AddAsync(EmaterialInvoice ematerialInvoice);
    Task<EmaterialInvoice> UpdateAsync(EmaterialInvoice ematerialInvoice);
    Task<EmaterialInvoice> DeleteAsync(EmaterialInvoice ematerialInvoice, bool permanent = false);
}
