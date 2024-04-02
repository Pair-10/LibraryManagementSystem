using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserNotifications.Commands.Delete;

public class DeletedUserNotificationResponse : IResponse
{
    public Guid Id { get; set; }
}