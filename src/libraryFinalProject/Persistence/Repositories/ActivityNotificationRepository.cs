using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ActivityNotificationRepository : EfRepositoryBase<ActivityNotification, Guid, BaseDbContext>, IActivityNotificationRepository
{
    public ActivityNotificationRepository(BaseDbContext context) : base(context)
    {
    }
}