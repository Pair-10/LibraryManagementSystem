using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserSurveys.Queries.GetList;

public class GetListUserSurveyListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }
}