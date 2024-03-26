using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Types;

public interface ITypeService
{
    Task<Type?> GetAsync(
        Expression<Func<Type, bool>> predicate,
        Func<IQueryable<Type>, IIncludableQueryable<Type, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Type>?> GetListAsync(
        Expression<Func<Type, bool>>? predicate = null,
        Func<IQueryable<Type>, IOrderedQueryable<Type>>? orderBy = null,
        Func<IQueryable<Type>, IIncludableQueryable<Type, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Type> AddAsync(Type type);
    Task<Type> UpdateAsync(Type type);
    Task<Type> DeleteAsync(Type type, bool permanent = false);
}
