using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserAddresses;

public interface IUserAddressService
{
    Task<UserAddress?> GetAsync(
        Expression<Func<UserAddress, bool>> predicate,
        Func<IQueryable<UserAddress>, IIncludableQueryable<UserAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserAddress>?> GetListAsync(
        Expression<Func<UserAddress, bool>>? predicate = null,
        Func<IQueryable<UserAddress>, IOrderedQueryable<UserAddress>>? orderBy = null,
        Func<IQueryable<UserAddress>, IIncludableQueryable<UserAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserAddress> AddAsync(UserAddress userAddress);
    Task<UserAddress> UpdateAsync(UserAddress userAddress);
    Task<UserAddress> DeleteAsync(UserAddress userAddress, bool permanent = false);
}
