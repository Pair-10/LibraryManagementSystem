using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserNotificationRepository : IAsyncRepository<UserNotification, Guid>, IRepository<UserNotification, Guid>
{
}