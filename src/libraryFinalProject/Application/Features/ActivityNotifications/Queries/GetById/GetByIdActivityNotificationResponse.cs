using NArchitecture.Core.Application.Responses;

namespace Application.Features.ActivityNotifications.Queries.GetById;

public class GetByIdActivityNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ActivityId { get; set; }
    public Guid NotificationId { get; set; }
}