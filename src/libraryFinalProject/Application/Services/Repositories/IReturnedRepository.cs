using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IReturnedRepository : IAsyncRepository<Returned, Guid>, IRepository<Returned, Guid>
{
}