using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserNotificationRepository : EfRepositoryBase<UserNotification, Guid, BaseDbContext>, IUserNotificationRepository
{
    public UserNotificationRepository(BaseDbContext context) : base(context)
    {
    }
}