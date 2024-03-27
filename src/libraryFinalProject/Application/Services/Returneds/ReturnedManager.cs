using Application.Features.Returneds.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Returneds;

public class ReturnedManager : IReturnedService
{
    private readonly IReturnedRepository _returnedRepository;
    private readonly ReturnedBusinessRules _returnedBusinessRules;

    public ReturnedManager(IReturnedRepository returnedRepository, ReturnedBusinessRules returnedBusinessRules)
    {
        _returnedRepository = returnedRepository;
        _returnedBusinessRules = returnedBusinessRules;
    }

    public async Task<Returned?> GetAsync(
        Expression<Func<Returned, bool>> predicate,
        Func<IQueryable<Returned>, IIncludableQueryable<Returned, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Returned? returned = await _returnedRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return returned;
    }

    public async Task<IPaginate<Returned>?> GetListAsync(
        Expression<Func<Returned, bool>>? predicate = null,
        Func<IQueryable<Returned>, IOrderedQueryable<Returned>>? orderBy = null,
        Func<IQueryable<Returned>, IIncludableQueryable<Returned, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Returned> returnedList = await _returnedRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return returnedList;
    }

    public async Task<Returned> AddAsync(Returned returned)
    {
        Returned addedReturned = await _returnedRepository.AddAsync(returned);

        return addedReturned;
    }

    public async Task<Returned> UpdateAsync(Returned returned)
    {
        Returned updatedReturned = await _returnedRepository.UpdateAsync(returned);

        return updatedReturned;
    }

    public async Task<Returned> DeleteAsync(Returned returned, bool permanent = false)
    {
        Returned deletedReturned = await _returnedRepository.DeleteAsync(returned);

        return deletedReturned;
    }
}
