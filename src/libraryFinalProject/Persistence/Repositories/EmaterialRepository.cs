using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EmaterialRepository : EfRepositoryBase<Ematerial, Guid, BaseDbContext>, IEmaterialRepository
{
    public EmaterialRepository(BaseDbContext context) : base(context)
    {
    }
}