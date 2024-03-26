using NArchitecture.Core.Application.Responses;

namespace Application.Features.ActivityNotifications.Commands.Delete;

public class DeletedActivityNotificationResponse : IResponse
{
    public Guid Id { get; set; }
}