using Application.Features.UserAddresses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserAddresses;

public class UserAddressManager : IUserAddressService
{
    private readonly IUserAddressRepository _userAddressRepository;
    private readonly UserAddressBusinessRules _userAddressBusinessRules;

    public UserAddressManager(IUserAddressRepository userAddressRepository, UserAddressBusinessRules userAddressBusinessRules)
    {
        _userAddressRepository = userAddressRepository;
        _userAddressBusinessRules = userAddressBusinessRules;
    }

    public async Task<UserAddress?> GetAsync(
        Expression<Func<UserAddress, bool>> predicate,
        Func<IQueryable<UserAddress>, IIncludableQueryable<UserAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserAddress? userAddress = await _userAddressRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userAddress;
    }

    public async Task<IPaginate<UserAddress>?> GetListAsync(
        Expression<Func<UserAddress, bool>>? predicate = null,
        Func<IQueryable<UserAddress>, IOrderedQueryable<UserAddress>>? orderBy = null,
        Func<IQueryable<UserAddress>, IIncludableQueryable<UserAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserAddress> userAddressList = await _userAddressRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userAddressList;
    }

    public async Task<UserAddress> AddAsync(UserAddress userAddress)
    {
        UserAddress addedUserAddress = await _userAddressRepository.AddAsync(userAddress);

        return addedUserAddress;
    }

    public async Task<UserAddress> UpdateAsync(UserAddress userAddress)
    {
        UserAddress updatedUserAddress = await _userAddressRepository.UpdateAsync(userAddress);

        return updatedUserAddress;
    }

    public async Task<UserAddress> DeleteAsync(UserAddress userAddress, bool permanent = false)
    {
        UserAddress deletedUserAddress = await _userAddressRepository.DeleteAsync(userAddress);

        return deletedUserAddress;
    }
}
