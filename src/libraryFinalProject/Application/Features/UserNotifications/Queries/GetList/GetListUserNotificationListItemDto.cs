using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserNotifications.Queries.GetList;

public class GetListUserNotificationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }
}