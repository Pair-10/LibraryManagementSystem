using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserNotifications.Commands.Update;

public class UpdatedUserNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }
}