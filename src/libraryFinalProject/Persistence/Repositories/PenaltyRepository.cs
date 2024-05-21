//using Application.Services.Repositories;
//using Domain.Entities;
//using NArchitecture.Core.Persistence.Repositories;
//using Persistence.Contexts;

//namespace Persistence.Repositories;

//public class PenaltyRepository : EfRepositoryBase<Penalty, Guid, BaseDbContext>, IPenaltyRepository
//{
//    public PenaltyRepository(BaseDbContext context) : base(context)
//    {

//    }
//}
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PenaltyRepository : EfRepositoryBase<Penalty, Guid, BaseDbContext>, IPenaltyRepository
{
    private readonly BaseDbContext _context;

    public PenaltyRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Penalty>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Penalty>().ToListAsync(cancellationToken);
    }
}

