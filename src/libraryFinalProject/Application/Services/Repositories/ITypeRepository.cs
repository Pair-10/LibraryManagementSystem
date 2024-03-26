using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITypeRepository : IAsyncRepository<Type, Guid>, IRepository<Type, Guid>
{
}