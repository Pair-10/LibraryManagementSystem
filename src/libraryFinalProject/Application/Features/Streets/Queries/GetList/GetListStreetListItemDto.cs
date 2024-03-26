using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Streets.Queries.GetList;

public class GetListStreetListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string StreetName { get; set; }
}