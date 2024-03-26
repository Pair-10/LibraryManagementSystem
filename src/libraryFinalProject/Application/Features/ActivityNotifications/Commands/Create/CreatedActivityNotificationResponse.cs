using NArchitecture.Core.Application.Responses;

namespace Application.Features.ActivityNotifications.Commands.Create;

public class CreatedActivityNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ActivityId { get; set; }
    public Guid NotificationId { get; set; }
}