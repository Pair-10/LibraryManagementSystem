using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderEMaterials;

public interface IOrderEMaterialService
{
    Task<OrderEMaterial?> GetAsync(
        Expression<Func<OrderEMaterial, bool>> predicate,
        Func<IQueryable<OrderEMaterial>, IIncludableQueryable<OrderEMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<OrderEMaterial>?> GetListAsync(
        Expression<Func<OrderEMaterial, bool>>? predicate = null,
        Func<IQueryable<OrderEMaterial>, IOrderedQueryable<OrderEMaterial>>? orderBy = null,
        Func<IQueryable<OrderEMaterial>, IIncludableQueryable<OrderEMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OrderEMaterial> AddAsync(OrderEMaterial orderEMaterial);
    Task<OrderEMaterial> UpdateAsync(OrderEMaterial orderEMaterial);
    Task<OrderEMaterial> DeleteAsync(OrderEMaterial orderEMaterial, bool permanent = false);
}
