using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notifications.Commands.Create;

public class CreatedNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public string NotificationDesc { get; set; }
    public DateTime NotificationDate { get; set; }
    public string NotificationType { get; set; }
    public bool NotificationStatus { get; set; }
}