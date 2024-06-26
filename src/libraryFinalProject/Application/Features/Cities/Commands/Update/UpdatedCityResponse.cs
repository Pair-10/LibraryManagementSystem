using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cities.Commands.Update;

public class UpdatedCityResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string CityName { get; set; }
}