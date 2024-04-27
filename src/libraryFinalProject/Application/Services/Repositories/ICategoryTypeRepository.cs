using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICategoryTypeRepository : IAsyncRepository<CategoryType, Guid>, IRepository<CategoryType, Guid>
{
}