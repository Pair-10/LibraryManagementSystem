using NArchitecture.Core.Application.Responses;

namespace Application.Features.Countries.Commands.Update;

public class UpdatedCountryResponse : IResponse
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }
}