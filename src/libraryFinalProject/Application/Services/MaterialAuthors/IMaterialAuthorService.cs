using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialAuthors;

public interface IMaterialAuthorService
{
    Task<MaterialAuthor?> GetAsync(
        Expression<Func<MaterialAuthor, bool>> predicate,
        Func<IQueryable<MaterialAuthor>, IIncludableQueryable<MaterialAuthor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaterialAuthor>?> GetListAsync(
        Expression<Func<MaterialAuthor, bool>>? predicate = null,
        Func<IQueryable<MaterialAuthor>, IOrderedQueryable<MaterialAuthor>>? orderBy = null,
        Func<IQueryable<MaterialAuthor>, IIncludableQueryable<MaterialAuthor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaterialAuthor> AddAsync(MaterialAuthor materialAuthor);
    Task<MaterialAuthor> UpdateAsync(MaterialAuthor materialAuthor);
    Task<MaterialAuthor> DeleteAsync(MaterialAuthor materialAuthor, bool permanent = false);
}
