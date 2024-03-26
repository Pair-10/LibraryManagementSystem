using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserActivities.Commands.Create;

public class CreatedUserActivityResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ActivityId { get; set; }
    public bool ParticipationStatus { get; set; }
    public DateTime ParticipationDate { get; set; }
}