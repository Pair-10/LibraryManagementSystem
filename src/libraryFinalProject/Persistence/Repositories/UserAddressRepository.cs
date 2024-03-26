using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserAddressRepository : EfRepositoryBase<UserAddress, Guid, BaseDbContext>, IUserAddressRepository
{
    public UserAddressRepository(BaseDbContext context) : base(context)
    {
    }
}