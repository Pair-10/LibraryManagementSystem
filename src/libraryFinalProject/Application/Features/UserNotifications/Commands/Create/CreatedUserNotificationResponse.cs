using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserNotifications.Commands.Create;

public class CreatedUserNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }
}