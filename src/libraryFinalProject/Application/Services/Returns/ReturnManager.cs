using Application.Features.Returns.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Returns;

public class ReturnManager : IReturnService
{
    private readonly IReturnRepository _returnRepository;
    private readonly ReturnBusinessRules _returnBusinessRules;

    public ReturnManager(IReturnRepository returnRepository, ReturnBusinessRules returnBusinessRules)
    {
        _returnRepository = returnRepository;
        _returnBusinessRules = returnBusinessRules;
    }

    public async Task<Return?> GetAsync(
        Expression<Func<Return, bool>> predicate,
        Func<IQueryable<Return>, IIncludableQueryable<Return, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Return? return = await _returnRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return return;
    }

    public async Task<IPaginate<Return>?> GetListAsync(
        Expression<Func<Return, bool>>? predicate = null,
        Func<IQueryable<Return>, IOrderedQueryable<Return>>? orderBy = null,
        Func<IQueryable<Return>, IIncludableQueryable<Return, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Return> returnList = await _returnRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return returnList;
    }

    public async Task<Return> AddAsync(Return return)
    {
        Return addedReturn = await _returnRepository.AddAsync(return);

        return addedReturn;
    }

    public async Task<Return> UpdateAsync(Return return)
    {
        Return updatedReturn = await _returnRepository.UpdateAsync(return);

        return updatedReturn;
    }

    public async Task<Return> DeleteAsync(Return return, bool permanent = false)
    {
        Return deletedReturn = await _returnRepository.DeleteAsync(return);

        return deletedReturn;
    }
}
