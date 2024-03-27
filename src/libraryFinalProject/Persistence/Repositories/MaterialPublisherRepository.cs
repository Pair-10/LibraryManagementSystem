using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialPublisherRepository : EfRepositoryBase<MaterialPublisher, Guid, BaseDbContext>, IMaterialPublisherRepository
{
    public MaterialPublisherRepository(BaseDbContext context) : base(context)
    {
    }
}