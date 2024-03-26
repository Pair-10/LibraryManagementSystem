using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserAddressRepository : IAsyncRepository<UserAddress, Guid>, IRepository<UserAddress, Guid>
{
}