using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialLocationRepository : IAsyncRepository<MaterialLocation, Guid>, IRepository<MaterialLocation, Guid>
{
}