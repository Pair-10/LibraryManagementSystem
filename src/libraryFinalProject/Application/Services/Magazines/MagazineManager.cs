using Application.Features.Magazines.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Magazines;

public class MagazineManager : IMagazineService
{
    private readonly IMagazineRepository _magazineRepository;
    private readonly MagazineBusinessRules _magazineBusinessRules;

    public MagazineManager(IMagazineRepository magazineRepository, MagazineBusinessRules magazineBusinessRules)
    {
        _magazineRepository = magazineRepository;
        _magazineBusinessRules = magazineBusinessRules;
    }

    public async Task<Magazine?> GetAsync(
        Expression<Func<Magazine, bool>> predicate,
        Func<IQueryable<Magazine>, IIncludableQueryable<Magazine, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Magazine? magazine = await _magazineRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return magazine;
    }

    public async Task<IPaginate<Magazine>?> GetListAsync(
        Expression<Func<Magazine, bool>>? predicate = null,
        Func<IQueryable<Magazine>, IOrderedQueryable<Magazine>>? orderBy = null,
        Func<IQueryable<Magazine>, IIncludableQueryable<Magazine, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Magazine> magazineList = await _magazineRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return magazineList;
    }

    public async Task<Magazine> AddAsync(Magazine magazine)
    {
        Magazine addedMagazine = await _magazineRepository.AddAsync(magazine);

        return addedMagazine;
    }

    public async Task<Magazine> UpdateAsync(Magazine magazine)
    {
        Magazine updatedMagazine = await _magazineRepository.UpdateAsync(magazine);

        return updatedMagazine;
    }

    public async Task<Magazine> DeleteAsync(Magazine magazine, bool permanent = false)
    {
        Magazine deletedMagazine = await _magazineRepository.DeleteAsync(magazine);

        return deletedMagazine;
    }
}
