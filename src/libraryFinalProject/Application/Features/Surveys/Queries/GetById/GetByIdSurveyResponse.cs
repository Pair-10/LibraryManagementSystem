using NArchitecture.Core.Application.Responses;

namespace Application.Features.Surveys.Queries.GetById;

public class GetByIdSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}