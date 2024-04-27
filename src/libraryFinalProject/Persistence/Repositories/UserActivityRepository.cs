using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserActivityRepository : EfRepositoryBase<UserActivity, Guid, BaseDbContext>, IUserActivityRepository
{
    public UserActivityRepository(BaseDbContext context) : base(context)
    {
    }
}