using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MagazineRepository : EfRepositoryBase<Magazine, Guid, BaseDbContext>, IMagazineRepository
{
    public MagazineRepository(BaseDbContext context) : base(context)
    {
    }
}