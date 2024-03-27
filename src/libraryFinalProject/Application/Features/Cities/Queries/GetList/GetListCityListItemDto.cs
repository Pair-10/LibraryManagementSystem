using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Cities.Queries.GetList;

public class GetListCityListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string CityName { get; set; }
}