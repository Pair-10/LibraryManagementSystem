using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialLocations;

public interface IMaterialLocationService
{
    Task<MaterialLocation?> GetAsync(
        Expression<Func<MaterialLocation, bool>> predicate,
        Func<IQueryable<MaterialLocation>, IIncludableQueryable<MaterialLocation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialLocation>?> GetListAsync(
        Expression<Func<MaterialLocation, bool>>? predicate = null,
        Func<IQueryable<MaterialLocation>, IOrderedQueryable<MaterialLocation>>? orderBy = null,
        Func<IQueryable<MaterialLocation>, IIncludableQueryable<MaterialLocation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialLocation> AddAsync(MaterialLocation materialLocation);
    Task<MaterialLocation> UpdateAsync(MaterialLocation materialLocation);
    Task<MaterialLocation> DeleteAsync(MaterialLocation materialLocation, bool permanent = false);
}
