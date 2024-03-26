using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ematerials;

public interface IEmaterialService
{
    Task<Ematerial?> GetAsync(
        Expression<Func<Ematerial, bool>> predicate,
        Func<IQueryable<Ematerial>, IIncludableQueryable<Ematerial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Ematerial>?> GetListAsync(
        Expression<Func<Ematerial, bool>>? predicate = null,
        Func<IQueryable<Ematerial>, IOrderedQueryable<Ematerial>>? orderBy = null,
        Func<IQueryable<Ematerial>, IIncludableQueryable<Ematerial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Ematerial> AddAsync(Ematerial ematerial);
    Task<Ematerial> UpdateAsync(Ematerial ematerial);
    Task<Ematerial> DeleteAsync(Ematerial ematerial, bool permanent = false);
}
