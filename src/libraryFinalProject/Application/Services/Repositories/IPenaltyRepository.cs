//using Domain.Entities;
//using NArchitecture.Core.Persistence.Repositories;

//namespace Application.Services.Repositories;

//public interface IPenaltyRepository : IAsyncRepository<Penalty, Guid>, IRepository<Penalty, Guid>
//{

//}
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPenaltyRepository : IAsyncRepository<Penalty, Guid>, IRepository<Penalty, Guid>
{
    //Task GetAllAsync(CancellationToken cancellationToken);
    Task<List<Penalty>> GetAllAsync(CancellationToken cancellationToken);
}


