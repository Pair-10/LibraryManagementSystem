using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Activities.Queries.GetList;

public class GetListActivityListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime ActivityDate { get; set; }
    public string Desc { get; set; }
    public string Status { get; set; }
    public string ActivityName { get; set; }
    public string Location { get; set; }
}