using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserActivityRepository : IAsyncRepository<UserActivity, Guid>, IRepository<UserActivity, Guid>
{
}