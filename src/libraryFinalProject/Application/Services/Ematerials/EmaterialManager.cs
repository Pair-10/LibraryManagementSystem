using Application.Features.Ematerials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ematerials;

public class EmaterialManager : IEmaterialService
{
    private readonly IEmaterialRepository _ematerialRepository;
    private readonly EmaterialBusinessRules _ematerialBusinessRules;

    public EmaterialManager(IEmaterialRepository ematerialRepository, EmaterialBusinessRules ematerialBusinessRules)
    {
        _ematerialRepository = ematerialRepository;
        _ematerialBusinessRules = ematerialBusinessRules;
    }

    public async Task<Ematerial?> GetAsync(
        Expression<Func<Ematerial, bool>> predicate,
        Func<IQueryable<Ematerial>, IIncludableQueryable<Ematerial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Ematerial? ematerial = await _ematerialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ematerial;
    }

    public async Task<IPaginate<Ematerial>?> GetListAsync(
        Expression<Func<Ematerial, bool>>? predicate = null,
        Func<IQueryable<Ematerial>, IOrderedQueryable<Ematerial>>? orderBy = null,
        Func<IQueryable<Ematerial>, IIncludableQueryable<Ematerial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Ematerial> ematerialList = await _ematerialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return ematerialList;
    }

    public async Task<Ematerial> AddAsync(Ematerial ematerial)
    {
        Ematerial addedEmaterial = await _ematerialRepository.AddAsync(ematerial);

        return addedEmaterial;
    }

    public async Task<Ematerial> UpdateAsync(Ematerial ematerial)
    {
        Ematerial updatedEmaterial = await _ematerialRepository.UpdateAsync(ematerial);

        return updatedEmaterial;
    }

    public async Task<Ematerial> DeleteAsync(Ematerial ematerial, bool permanent = false)
    {
        Ematerial deletedEmaterial = await _ematerialRepository.DeleteAsync(ematerial);

        return deletedEmaterial;
    }
}
