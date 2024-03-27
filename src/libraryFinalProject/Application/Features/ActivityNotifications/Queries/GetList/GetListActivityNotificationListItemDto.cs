using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ActivityNotifications.Queries.GetList;

public class GetListActivityNotificationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ActivityId { get; set; }
    public Guid NotificationId { get; set; }
}