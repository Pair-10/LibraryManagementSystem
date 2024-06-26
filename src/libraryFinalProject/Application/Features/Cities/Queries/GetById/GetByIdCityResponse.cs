using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cities.Queries.GetById;

public class GetByIdCityResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string CityName { get; set; }
}