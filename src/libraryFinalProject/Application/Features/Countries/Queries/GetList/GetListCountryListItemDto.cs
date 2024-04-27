using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Countries.Queries.GetList;

public class GetListCountryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }
}