namespace Application.Features.Notifications.Constants;

public static class NotificationsBusinessMessages
{
    public const string SectionName = "Notifications";

    public const string NotificationNotExists = "NotificationNotExists";
    public const string InvalidDateFormat = "The notification date must be later than today";
    public const string DescMustBeLength = "Notification description must be at least 3 and at most 250 characters.";
}