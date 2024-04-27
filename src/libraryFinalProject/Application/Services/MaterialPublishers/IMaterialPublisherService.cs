using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialPublishers;

public interface IMaterialPublisherService
{
    Task<MaterialPublisher?> GetAsync(
        Expression<Func<MaterialPublisher, bool>> predicate,
        Func<IQueryable<MaterialPublisher>, IIncludableQueryable<MaterialPublisher, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialPublisher>?> GetListAsync(
        Expression<Func<MaterialPublisher, bool>>? predicate = null,
        Func<IQueryable<MaterialPublisher>, IOrderedQueryable<MaterialPublisher>>? orderBy = null,
        Func<IQueryable<MaterialPublisher>, IIncludableQueryable<MaterialPublisher, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialPublisher> AddAsync(MaterialPublisher materialPublisher);
    Task<MaterialPublisher> UpdateAsync(MaterialPublisher materialPublisher);
    Task<MaterialPublisher> DeleteAsync(MaterialPublisher materialPublisher, bool permanent = false);
}
