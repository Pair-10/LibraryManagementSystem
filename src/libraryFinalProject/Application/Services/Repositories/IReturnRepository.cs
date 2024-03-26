using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IReturnRepository : IAsyncRepository<Return, Guid>, IRepository<Return, Guid>
{
}