using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMagazineRepository : IAsyncRepository<Magazine, Guid>, IRepository<Magazine, Guid>
{
}