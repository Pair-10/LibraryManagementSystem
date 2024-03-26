using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialTranslators;

public interface IMaterialTranslatorService
{
    Task<MaterialTranslator?> GetAsync(
        Expression<Func<MaterialTranslator, bool>> predicate,
        Func<IQueryable<MaterialTranslator>, IIncludableQueryable<MaterialTranslator, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialTranslator>?> GetListAsync(
        Expression<Func<MaterialTranslator, bool>>? predicate = null,
        Func<IQueryable<MaterialTranslator>, IOrderedQueryable<MaterialTranslator>>? orderBy = null,
        Func<IQueryable<MaterialTranslator>, IIncludableQueryable<MaterialTranslator, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialTranslator> AddAsync(MaterialTranslator materialTranslator);
    Task<MaterialTranslator> UpdateAsync(MaterialTranslator materialTranslator);
    Task<MaterialTranslator> DeleteAsync(MaterialTranslator materialTranslator, bool permanent = false);
}
