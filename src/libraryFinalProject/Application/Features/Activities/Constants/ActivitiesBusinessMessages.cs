namespace Application.Features.Activities.Constants;

public static class ActivitiesBusinessMessages
{
    public const string SectionName = "Activities";

    public const string ActivityNotExists = "ActivityNotExists";
    public const string ActivityAlreadyExist = "ActivityNameAlreadyExist";//Ayný isme sahip bir etkinlik zaten mevcut
    public const string InvalidActivityDate = "InvalidActivityDate";
    public const string DescCannotExceed250Characters = "DescCannotExceed250Characters";
}