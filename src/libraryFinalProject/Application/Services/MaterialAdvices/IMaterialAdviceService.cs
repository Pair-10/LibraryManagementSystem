using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialAdvices;

public interface IMaterialAdviceService
{
    Task<MaterialAdvice?> GetAsync(
        Expression<Func<MaterialAdvice, bool>> predicate,
        Func<IQueryable<MaterialAdvice>, IIncludableQueryable<MaterialAdvice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialAdvice>?> GetListAsync(
        Expression<Func<MaterialAdvice, bool>>? predicate = null,
        Func<IQueryable<MaterialAdvice>, IOrderedQueryable<MaterialAdvice>>? orderBy = null,
        Func<IQueryable<MaterialAdvice>, IIncludableQueryable<MaterialAdvice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialAdvice> AddAsync(MaterialAdvice materialAdvice);
    Task<MaterialAdvice> UpdateAsync(MaterialAdvice materialAdvice);
    Task<MaterialAdvice> DeleteAsync(MaterialAdvice materialAdvice, bool permanent = false);
}
