using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEmaterialRepository : IAsyncRepository<Ematerial, Guid>, IRepository<Ematerial, Guid>
{
}