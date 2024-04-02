using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserNotifications.Queries.GetById;

public class GetByIdUserNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }
}