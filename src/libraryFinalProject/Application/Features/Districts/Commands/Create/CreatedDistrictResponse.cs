using NArchitecture.Core.Application.Responses;

namespace Application.Features.Districts.Commands.Create;

public class CreatedDistrictResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string DistrictName { get; set; }
}