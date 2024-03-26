using NArchitecture.Core.Application.Responses;

namespace Application.Features.Activities.Commands.Create;

public class CreatedActivityResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime ActivityDate { get; set; }
    public string Desc { get; set; }
    public string Status { get; set; }
    public string ActivityName { get; set; }
    public string Location { get; set; }
}