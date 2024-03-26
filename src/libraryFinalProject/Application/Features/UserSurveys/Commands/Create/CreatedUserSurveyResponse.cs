using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserSurveys.Commands.Create;

public class CreatedUserSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }
}