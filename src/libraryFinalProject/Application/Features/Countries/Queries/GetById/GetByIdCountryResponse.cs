using NArchitecture.Core.Application.Responses;

namespace Application.Features.Countries.Queries.GetById;

public class GetByIdCountryResponse : IResponse
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }
}