using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ReturnedRepository : EfRepositoryBase<Returned, Guid, BaseDbContext>, IReturnedRepository
{
    public ReturnedRepository(BaseDbContext context) : base(context)
    {
    }
}