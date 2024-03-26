using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Notifications.Queries.GetList;

public class GetListNotificationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string NotificationDesc { get; set; }
    public DateTime NotificationDate { get; set; }
    public string NotificationType { get; set; }
    public bool NotificationStatus { get; set; }
}