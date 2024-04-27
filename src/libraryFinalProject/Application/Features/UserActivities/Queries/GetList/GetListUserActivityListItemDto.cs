using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserActivities.Queries.GetList;

public class GetListUserActivityListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ActivityId { get; set; }
    public bool ParticipationStatus { get; set; }
    public DateTime ParticipationDate { get; set; }
}