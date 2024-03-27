using Application.Features.MaterialLocations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialLocations;

public class MaterialLocationManager : IMaterialLocationService
{
    private readonly IMaterialLocationRepository _materialLocationRepository;
    private readonly MaterialLocationBusinessRules _materialLocationBusinessRules;

    public MaterialLocationManager(IMaterialLocationRepository materialLocationRepository, MaterialLocationBusinessRules materialLocationBusinessRules)
    {
        _materialLocationRepository = materialLocationRepository;
        _materialLocationBusinessRules = materialLocationBusinessRules;
    }

    public async Task<MaterialLocation?> GetAsync(
        Expression<Func<MaterialLocation, bool>> predicate,
        Func<IQueryable<MaterialLocation>, IIncludableQueryable<MaterialLocation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialLocation? materialLocation = await _materialLocationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialLocation;
    }

    public async Task<IPaginate<MaterialLocation>?> GetListAsync(
        Expression<Func<MaterialLocation, bool>>? predicate = null,
        Func<IQueryable<MaterialLocation>, IOrderedQueryable<MaterialLocation>>? orderBy = null,
        Func<IQueryable<MaterialLocation>, IIncludableQueryable<MaterialLocation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialLocation> materialLocationList = await _materialLocationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialLocationList;
    }

    public async Task<MaterialLocation> AddAsync(MaterialLocation materialLocation)
    {
        MaterialLocation addedMaterialLocation = await _materialLocationRepository.AddAsync(materialLocation);

        return addedMaterialLocation;
    }

    public async Task<MaterialLocation> UpdateAsync(MaterialLocation materialLocation)
    {
        MaterialLocation updatedMaterialLocation = await _materialLocationRepository.UpdateAsync(materialLocation);

        return updatedMaterialLocation;
    }

    public async Task<MaterialLocation> DeleteAsync(MaterialLocation materialLocation, bool permanent = false)
    {
        MaterialLocation deletedMaterialLocation = await _materialLocationRepository.DeleteAsync(materialLocation);

        return deletedMaterialLocation;
    }
}
