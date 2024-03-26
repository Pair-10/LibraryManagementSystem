using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IActivityNotificationRepository : IAsyncRepository<ActivityNotification, Guid>, IRepository<ActivityNotification, Guid>
{
}