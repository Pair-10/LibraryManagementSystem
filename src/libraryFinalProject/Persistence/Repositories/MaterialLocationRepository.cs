using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialLocationRepository : EfRepositoryBase<MaterialLocation, Guid, BaseDbContext>, IMaterialLocationRepository
{
    public MaterialLocationRepository(BaseDbContext context) : base(context)
    {
    }
}