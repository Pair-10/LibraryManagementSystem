using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ReturnRepository : EfRepositoryBase<Return, Guid, BaseDbContext>, IReturnRepository
{
    public ReturnRepository(BaseDbContext context) : base(context)
    {
    }
}