using Application.Features.EmaterialInvoices.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EmaterialInvoices;

public class EmaterialInvoiceManager : IEmaterialInvoiceService
{
    private readonly IEmaterialInvoiceRepository _ematerialInvoiceRepository;
    private readonly EmaterialInvoiceBusinessRules _ematerialInvoiceBusinessRules;

    public EmaterialInvoiceManager(IEmaterialInvoiceRepository ematerialInvoiceRepository, EmaterialInvoiceBusinessRules ematerialInvoiceBusinessRules)
    {
        _ematerialInvoiceRepository = ematerialInvoiceRepository;
        _ematerialInvoiceBusinessRules = ematerialInvoiceBusinessRules;
    }

    public async Task<EmaterialInvoice?> GetAsync(
        Expression<Func<EmaterialInvoice, bool>> predicate,
        Func<IQueryable<EmaterialInvoice>, IIncludableQueryable<EmaterialInvoice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EmaterialInvoice? ematerialInvoice = await _ematerialInvoiceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ematerialInvoice;
    }

    public async Task<IPaginate<EmaterialInvoice>?> GetListAsync(
        Expression<Func<EmaterialInvoice, bool>>? predicate = null,
        Func<IQueryable<EmaterialInvoice>, IOrderedQueryable<EmaterialInvoice>>? orderBy = null,
        Func<IQueryable<EmaterialInvoice>, IIncludableQueryable<EmaterialInvoice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EmaterialInvoice> ematerialInvoiceList = await _ematerialInvoiceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return ematerialInvoiceList;
    }

    public async Task<EmaterialInvoice> AddAsync(EmaterialInvoice ematerialInvoice)
    {
        EmaterialInvoice addedEmaterialInvoice = await _ematerialInvoiceRepository.AddAsync(ematerialInvoice);

        return addedEmaterialInvoice;
    }

    public async Task<EmaterialInvoice> UpdateAsync(EmaterialInvoice ematerialInvoice)
    {
        EmaterialInvoice updatedEmaterialInvoice = await _ematerialInvoiceRepository.UpdateAsync(ematerialInvoice);

        return updatedEmaterialInvoice;
    }

    public async Task<EmaterialInvoice> DeleteAsync(EmaterialInvoice ematerialInvoice, bool permanent = false)
    {
        EmaterialInvoice deletedEmaterialInvoice = await _ematerialInvoiceRepository.DeleteAsync(ematerialInvoice);

        return deletedEmaterialInvoice;
    }
}
